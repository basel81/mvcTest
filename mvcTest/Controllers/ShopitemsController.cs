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
    public class ShopitemsController : Controller
    {
        private readonly YourDirContext _context;

        public ShopitemsController(YourDirContext context)
        {
            _context = context;
        }

        // GET: Shopitems
        public async Task<IActionResult> Index()
        {
            var yourDirContext = _context.Shopitem.Include(s => s.Item).Include(s => s.Shop);
            return View(await yourDirContext.ToListAsync());
        }

        // GET: Shopitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopitem = await _context.Shopitem
                .Include(s => s.Item)
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.ShopItemId == id);
            if (shopitem == null)
            {
                return NotFound();
            }

            return View(shopitem);
        }

        // GET: Shopitems/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Itemstosale, "ItemId", "Aname");
            ViewData["ShopId"] = new SelectList(_context.Shop, "ShopId", "Address");
            return View();
        }

        // POST: Shopitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopItemId,ItemId,ShopId")] Shopitem shopitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Itemstosale, "ItemId", "Aname", shopitem.ItemId);
            ViewData["ShopId"] = new SelectList(_context.Shop, "ShopId", "Address", shopitem.ShopId);
            return View(shopitem);
        }

        // GET: Shopitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopitem = await _context.Shopitem.FindAsync(id);
            if (shopitem == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Itemstosale, "ItemId", "Aname", shopitem.ItemId);
            ViewData["ShopId"] = new SelectList(_context.Shop, "ShopId", "Address", shopitem.ShopId);
            return View(shopitem);
        }

        // POST: Shopitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopItemId,ItemId,ShopId")] Shopitem shopitem)
        {
            if (id != shopitem.ShopItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopitemExists(shopitem.ShopItemId))
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
            ViewData["ItemId"] = new SelectList(_context.Itemstosale, "ItemId", "Aname", shopitem.ItemId);
            ViewData["ShopId"] = new SelectList(_context.Shop, "ShopId", "Address", shopitem.ShopId);
            return View(shopitem);
        }

        // GET: Shopitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopitem = await _context.Shopitem
                .Include(s => s.Item)
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.ShopItemId == id);
            if (shopitem == null)
            {
                return NotFound();
            }

            return View(shopitem);
        }

        // POST: Shopitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopitem = await _context.Shopitem.FindAsync(id);
            _context.Shopitem.Remove(shopitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopitemExists(int id)
        {
            return _context.Shopitem.Any(e => e.ShopItemId == id);
        }
    }
}
