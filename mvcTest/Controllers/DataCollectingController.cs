using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcTest.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace mvcTest.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class DataCollectingController : Controller
    {

        YourDirContext _context;


        public DataCollectingController(YourDirContext context)
        {
            _context = context;

        }



        [HttpGet("getCategories")]
        public IActionResult getCategories()
        {
            return Ok(_context.Category.ToList());
        }

        [HttpGet("CollectorVerfication")]

        public IActionResult CollectorVerfication(string userName, string mac)
        {

            //  Employee user = await _userManager.FindByEmailAsync(input.Email);
            // var result = await _signInManager.PasswordSignInAsync(user.UserName, input.Password, false, lockoutOnFailure: false);
            if (userName != null && mac != null)
            {
                Datacollector result = _context.Datacollector.Where(p => p.Macaddress.Equals(mac) && p.UserName.Equals(userName)).FirstOrDefault();
                if (result != null)
                {
                    return Ok(new
                    {
                        id = result.Dcid
                    }
                        );
                }
                return Unauthorized();
            }
            return BadRequest();

        }

        [HttpGet("getShoptypes/{categoryId}")]
        public List<Shoptype> getShoptypes(int categoryId)
        {
            List<Shoptype> shoptypes = _context.Shoptype.Where(p => p.CategoryId == categoryId).ToList();
            return shoptypes;
        }

        [HttpPost]
        public async Task<IActionResult> AddReferencePoint(string aName, string EName, string location)
        {
            if (aName != null && EName != null && location != null)
            {
                Referencepoint rp = new Referencepoint();
                rp.AName = aName;
                rp.EName = EName;
                rp.Location = location;
                _context.Referencepoint.Add(rp);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok(200);
                }
                catch
                {
                    return BadRequest("can not add reference Point to database");
                }
            }
            return BadRequest("Please Fill All Data");
        }

        [HttpGet("getAllInputScreenData/{categoryId}")]
        public IActionResult getAllInputScreenData(int categoryId)
        {
            return Ok(new
            {
                categoryItems = getCategoryItems(categoryId),
                referencPoints = getAllreferencePoint()
            });
        }

        [HttpGet("getCategoryItems/{categoryId}")]
        public List<Itemstosale> getCategoryItems(int categoryId)
        {
            List<Itemstosale> items = new List<Itemstosale>();
            items = _context.Itemstosale.Where(p => p.CategoryId == categoryId).ToList();
            return items;
        }

        [HttpPost]
        public async Task<IActionResult> addCategoryItems(int categoryId, string aName, string eName)
        {
            if (categoryId != 0 && aName != null && eName != null)
            {
                Itemstosale item = new Itemstosale()
                {
                    CategoryId = categoryId,
                    Aname = aName,
                    Ename = eName
                };
                _context.Itemstosale.Add(item);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok(200);
                }
                catch (Exception ex)
                {
                    return BadRequest("can not add reference Point to database");
                }
            }
            return BadRequest("Please Fill All Data");
        }
        [HttpGet("getAllreferencePoint")]
        public List<Referencepoint> getAllreferencePoint()
        {
            return _context.Referencepoint.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> addShopItem(int shopId, int itemId)
        {
            Shopitem shopitem = new Shopitem();
            shopitem.ItemId = itemId;
            shopitem.ShopId = shopId;
            _context.Shopitem.Add(shopitem);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(shopitem);
            }
            catch
            {
                return BadRequest("can not add shop item to database");
            }

        }
        [HttpPost]
        public async Task<Boolean> addShopItems(int shopId, int[] itemIds)
        {
            foreach (int itemId in itemIds)
            {
                Shopitem item = new Shopitem()
                {
                    ShopId = shopId,
                    ItemId = itemId
                };
                _context.Shopitem.Add(item);
                try
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return true;

        }
        [HttpPost]
        public async Task<IActionResult> AddShop(string notes, string phone, string site, string mobile,
        string Properties, string Twiter,
        string location, string facebook, string EshopName, string shopName, string country, string city, string address, int referencePointId
        , int shopTypeId,
        string items,
        int userId
        )
        {
            Datacollector dataCollector = _context.Datacollector.Where(p => p.Dcid == userId).FirstOrDefault();
            if (phone != null &&
                site != null &&
                mobile != null &&
                Properties != null &&
                Twiter != null &&
                location != null &&
                facebook != null &&
                EshopName != null &&
                shopName != null &&
                country != null &&
                address != null &&
                shopTypeId != 0 &&
                referencePointId != 0 &&
                items != null &&
                dataCollector != null
                 )
            {
                Shop shop = new Shop();
                shop.Notes = "notes";
                shop.ShopName = shopName;
                shop.ShopTypeId = shopTypeId;
                shop.ActivationDate = DateTime.Now;
                shop.Address = address;
                shop.City = dataCollector.Address;
                shop.Country = country;
                shop.EshopName = EshopName;
                shop.Facebook = facebook;
                shop.Location = location;
                shop.Mobile = mobile;
                shop.Phone = phone;
                shop.Properties = Properties;
                shop.ReferencePointId = referencePointId;
                shop.RegisterationDate = DateTime.Now;
                shop.Twiter = Twiter;
                shop.Website = site;

                shop = _context.Shop.Add(shop).Entity;
                try
                {
                    await _context.SaveChangesAsync();
                    // var result =await addShopItems(items);
                    // JArray json = JArray.Parse(items);
                    int[] values = JsonConvert.DeserializeObject<int[]>(items);
                    Boolean result = await addShopItems(shop.ShopId, values);
                    if (result)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        _context.Shop.Remove(shop);
                        await _context.SaveChangesAsync();
                        return BadRequest("select shop items");
                    }

                }
                catch
                {
                    return BadRequest("can not add reference Point to database");
                }
            }
            return BadRequest("Please Fill All Data");
        }
    }
}

