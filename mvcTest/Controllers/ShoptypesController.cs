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
    public class ShoptypesController : Controller
    {
        private readonly YourDirContext _context;

        public ShoptypesController(YourDirContext context)
        {
            _context = context;
        }

        // GET: Shoptypes
        public async Task<IActionResult> Index()
        {
            var yourDirContext = _context.Shoptype.Include(s => s.Category);
            return View(await yourDirContext.ToListAsync());
        }

        // GET: Shoptypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoptype = await _context.Shoptype
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.ShopTypeId == id);
            if (shoptype == null)
            {
                return NotFound();
            }

            return View(shoptype);
        }

        // GET: Shoptypes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategorId", "CategoryEname");
            return View();
        }

        // POST: Shoptypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopTypeId,Aname,Ename,Aliases,Ealiases,Photo,CategoryId")] Shoptype shoptype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoptype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategorId", "CategoryEname", shoptype.CategoryId);
            return View(shoptype);
        }

        // GET: Shoptypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoptype = await _context.Shoptype.FindAsync(id);
            if (shoptype == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategorId", "CategoryEname", shoptype.CategoryId);
            return View(shoptype);
        }

        // POST: Shoptypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopTypeId,Aname,Ename,Aliases,Ealiases,Photo,CategoryId")] Shoptype shoptype)
        {
            if (id != shoptype.ShopTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoptype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoptypeExists(shoptype.ShopTypeId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategorId", "CategoryEname", shoptype.CategoryId);
            return View(shoptype);
        }

        // GET: Shoptypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoptype = await _context.Shoptype
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.ShopTypeId == id);
            if (shoptype == null)
            {
                return NotFound();
            }

            return View(shoptype);
        }

        // POST: Shoptypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoptype = await _context.Shoptype.FindAsync(id);
            _context.Shoptype.Remove(shoptype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoptypeExists(int id)
        {
            return _context.Shoptype.Any(e => e.ShopTypeId == id);
        }
    }
}
