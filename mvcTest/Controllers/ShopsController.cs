using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcTest.Models;

namespace mvcTest.Controllers
{
    public class ShopsController : Controller
    {
        private readonly YourDirContext _context;

        public ShopsController(YourDirContext context)
        {
            _context = context;
        }

        // GET: Shops
        public async Task<IActionResult> Index()
        {
            var yourDirContext = _context.Shop.Include(s => s.ReferencePoint).Include(s => s.ShopType);
            return View(await yourDirContext.ToListAsync());
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop
                .Include(s => s.ReferencePoint)
                .Include(s => s.ShopType)
                .FirstOrDefaultAsync(m => m.ShopId == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // GET: Shops/Create
        public IActionResult Create()
        {
            ViewData["ReferencePointId"] = new SelectList(_context.Referencepoint, "ReferencePointId", "AName");
            ViewData["ShopTypeId"] = new SelectList(_context.Shoptype, "ShopTypeId", "Aliases");
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopId,ShopTypeId,ShopName,EshopName,Address,City,Country,Location,Properties,Phone,Mobile,Facebook,Twiter,Website,RegisterationDate,ActivationDate,ReferencePointId,Notes")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReferencePointId"] = new SelectList(_context.Referencepoint, "ReferencePointId", "AName", shop.ReferencePointId);
            ViewData["ShopTypeId"] = new SelectList(_context.Shoptype, "ShopTypeId", "Aliases", shop.ShopTypeId);
            return View(shop);
        }

        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            ViewData["ReferencePointId"] = new SelectList(_context.Referencepoint, "ReferencePointId", "AName", shop.ReferencePointId);
            ViewData["ShopTypeId"] = new SelectList(_context.Shoptype, "ShopTypeId", "Aliases", shop.ShopTypeId);
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopId,ShopTypeId,ShopName,EshopName,Address,City,Country,Location,Properties,Phone,Mobile,Facebook,Twiter,Website,RegisterationDate,ActivationDate,ReferencePointId,Notes")] Shop shop)
        {
            if (id != shop.ShopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.ShopId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReferencePointId"] = new SelectList(_context.Referencepoint, "ReferencePointId", "AName", shop.ReferencePointId);
            ViewData["ShopTypeId"] = new SelectList(_context.Shoptype, "ShopTypeId", "Aliases", shop.ShopTypeId);
            return View(shop);
        }

        // GET: Shops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop
                .Include(s => s.ReferencePoint)
                .Include(s => s.ShopType)
                .FirstOrDefaultAsync(m => m.ShopId == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shop = await _context.Shop.FindAsync(id);
            _context.Shop.Remove(shop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopExists(int id)
        {
            return _context.Shop.Any(e => e.ShopId == id);
        }
    }
}
