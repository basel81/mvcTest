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
    public class ItemstosalesController : Controller
    {
        private readonly YourDirContext _context;

        public ItemstosalesController(YourDirContext context)
        {
            _context = context;
        }

        // GET: Itemstosales
        public async Task<IActionResult> Index()
        {
            var yourDirContext = _context.Itemstosale.Include(i => i.Category);
            return View(await yourDirContext.ToListAsync());
        }

        // GET: Itemstosales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemstosale = await _context.Itemstosale
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemstosale == null)
            {
                return NotFound();
            }

            return View(itemstosale);
        }

        // GET: Itemstosales/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategorId", "CategoryEname");
            return View();
        }

        // POST: Itemstosales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,CategoryId,Aname,Ename")] Itemstosale itemstosale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemstosale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategorId", "CategoryEname", itemstosale.CategoryId);
            return View(itemstosale);
        }

        // GET: Itemstosales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemstosale = await _context.Itemstosale.FindAsync(id);
            if (itemstosale == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategorId", "CategoryEname", itemstosale.CategoryId);
            return View(itemstosale);
        }

        // POST: Itemstosales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,CategoryId,Aname,Ename")] Itemstosale itemstosale)
        {
            if (id != itemstosale.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemstosale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemstosaleExists(itemstosale.ItemId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategorId", "CategoryEname", itemstosale.CategoryId);
            return View(itemstosale);
        }

        // GET: Itemstosales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemstosale = await _context.Itemstosale
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemstosale == null)
            {
                return NotFound();
            }

            return View(itemstosale);
        }

        // POST: Itemstosales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemstosale = await _context.Itemstosale.FindAsync(id);
            _context.Itemstosale.Remove(itemstosale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemstosaleExists(int id)
        {
            return _context.Itemstosale.Any(e => e.ItemId == id);
        }
    }
}
