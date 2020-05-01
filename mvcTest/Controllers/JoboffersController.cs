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
    public class JoboffersController : Controller
    {
        private readonly YourDirContext _context;

        public JoboffersController(YourDirContext context)
        {
            _context = context;
        }

        // GET: Joboffers
        public async Task<IActionResult> Index()
        {
            var yourDirContext = _context.Joboffer.Include(j => j.Client);
            return View(await yourDirContext.ToListAsync());
        }

        // GET: Joboffers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffer = await _context.Joboffer
                .Include(j => j.Client)
                .FirstOrDefaultAsync(m => m.JobOfferId == id);
            if (joboffer == null)
            {
                return NotFound();
            }

            return View(joboffer);
        }

        // GET: Joboffers/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address");
            return View();
        }

        // POST: Joboffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobOfferId,ClientId,OfferText,OfferTitle,OfferDate,Days,Cost")] Joboffer joboffer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joboffer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address", joboffer.ClientId);
            return View(joboffer);
        }

        // GET: Joboffers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffer = await _context.Joboffer.FindAsync(id);
            if (joboffer == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address", joboffer.ClientId);
            return View(joboffer);
        }

        // POST: Joboffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobOfferId,ClientId,OfferText,OfferTitle,OfferDate,Days,Cost")] Joboffer joboffer)
        {
            if (id != joboffer.JobOfferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joboffer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobofferExists(joboffer.JobOfferId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address", joboffer.ClientId);
            return View(joboffer);
        }

        // GET: Joboffers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffer = await _context.Joboffer
                .Include(j => j.Client)
                .FirstOrDefaultAsync(m => m.JobOfferId == id);
            if (joboffer == null)
            {
                return NotFound();
            }

            return View(joboffer);
        }

        // POST: Joboffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joboffer = await _context.Joboffer.FindAsync(id);
            _context.Joboffer.Remove(joboffer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobofferExists(int id)
        {
            return _context.Joboffer.Any(e => e.JobOfferId == id);
        }
    }
}
