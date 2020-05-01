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
    public class ReferencepointsController : Controller
    {
        private readonly YourDirContext _context;

        public ReferencepointsController(YourDirContext context)
        {
            _context = context;
        }

        // GET: Referencepoints
        public async Task<IActionResult> Index()
        {
            return View(await _context.Referencepoint.ToListAsync());
        }

        // GET: Referencepoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referencepoint = await _context.Referencepoint
                .FirstOrDefaultAsync(m => m.ReferencePointId == id);
            if (referencepoint == null)
            {
                return NotFound();
            }

            return View(referencepoint);
        }

        // GET: Referencepoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Referencepoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferencePointId,AName,Location,EName")] Referencepoint referencepoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referencepoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(referencepoint);
        }

        // GET: Referencepoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referencepoint = await _context.Referencepoint.FindAsync(id);
            if (referencepoint == null)
            {
                return NotFound();
            }
            return View(referencepoint);
        }

        // POST: Referencepoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReferencePointId,AName,Location,EName")] Referencepoint referencepoint)
        {
            if (id != referencepoint.ReferencePointId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referencepoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferencepointExists(referencepoint.ReferencePointId))
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
            return View(referencepoint);
        }

        // GET: Referencepoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referencepoint = await _context.Referencepoint
                .FirstOrDefaultAsync(m => m.ReferencePointId == id);
            if (referencepoint == null)
            {
                return NotFound();
            }

            return View(referencepoint);
        }

        // POST: Referencepoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referencepoint = await _context.Referencepoint.FindAsync(id);
            _context.Referencepoint.Remove(referencepoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferencepointExists(int id)
        {
            return _context.Referencepoint.Any(e => e.ReferencePointId == id);
        }
    }
}
