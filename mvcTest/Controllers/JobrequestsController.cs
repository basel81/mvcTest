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
    public class JobrequestsController : Controller
    {
        private readonly YourDirContext _context;

        public JobrequestsController(YourDirContext context)
        {
            _context = context;
        }

        // GET: Jobrequests
        public async Task<IActionResult> Index()
        {
            var yourDirContext = _context.Jobrequest.Include(j => j.Client);
            return View(await yourDirContext.ToListAsync());
        }

        // GET: Jobrequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobrequest = await _context.Jobrequest
                .Include(j => j.Client)
                .FirstOrDefaultAsync(m => m.JobRequestId == id);
            if (jobrequest == null)
            {
                return NotFound();
            }

            return View(jobrequest);
        }

        // GET: Jobrequests/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address");
            return View();
        }

        // POST: Jobrequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobRequestId,ClientId,RequestTitle,RequestText,RequestDate,Days,Cost")] Jobrequest jobrequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobrequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address", jobrequest.ClientId);
            return View(jobrequest);
        }

        // GET: Jobrequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobrequest = await _context.Jobrequest.FindAsync(id);
            if (jobrequest == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address", jobrequest.ClientId);
            return View(jobrequest);
        }

        // POST: Jobrequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobRequestId,ClientId,RequestTitle,RequestText,RequestDate,Days,Cost")] Jobrequest jobrequest)
        {
            if (id != jobrequest.JobRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobrequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobrequestExists(jobrequest.JobRequestId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address", jobrequest.ClientId);
            return View(jobrequest);
        }

        // GET: Jobrequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobrequest = await _context.Jobrequest
                .Include(j => j.Client)
                .FirstOrDefaultAsync(m => m.JobRequestId == id);
            if (jobrequest == null)
            {
                return NotFound();
            }

            return View(jobrequest);
        }

        // POST: Jobrequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobrequest = await _context.Jobrequest.FindAsync(id);
            _context.Jobrequest.Remove(jobrequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobrequestExists(int id)
        {
            return _context.Jobrequest.Any(e => e.JobRequestId == id);
        }
    }
}
