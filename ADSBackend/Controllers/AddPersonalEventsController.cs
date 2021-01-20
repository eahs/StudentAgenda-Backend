using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADSBackend.Data;
using ADSBackend.Models;

namespace ADSBackend.Controllers
{
    public class AddPersonalEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddPersonalEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddPersonalEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddPersonalEvent.ToListAsync());
        }

        // GET: AddPersonalEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addPersonalEvent = await _context.AddPersonalEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addPersonalEvent == null)
            {
                return NotFound();
            }

            return View(addPersonalEvent);
        }

        // GET: AddPersonalEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddPersonalEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PNameOfEvent,dateOfEvent,PDateOfEvent,PTimeNeeded,Pdescription")] AddPersonalEvent addPersonalEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addPersonalEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addPersonalEvent);
        }

        // GET: AddPersonalEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addPersonalEvent = await _context.AddPersonalEvent.FindAsync(id);
            if (addPersonalEvent == null)
            {
                return NotFound();
            }
            return View(addPersonalEvent);
        }

        // POST: AddPersonalEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PNameOfEvent,dateOfEvent,PDateOfEvent,PTimeNeeded,Pdescription")] AddPersonalEvent addPersonalEvent)
        {
            if (id != addPersonalEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addPersonalEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddPersonalEventExists(addPersonalEvent.Id))
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
            return View(addPersonalEvent);
        }

        // GET: AddPersonalEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addPersonalEvent = await _context.AddPersonalEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addPersonalEvent == null)
            {
                return NotFound();
            }

            return View(addPersonalEvent);
        }

        // POST: AddPersonalEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addPersonalEvent = await _context.AddPersonalEvent.FindAsync(id);
            _context.AddPersonalEvent.Remove(addPersonalEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddPersonalEventExists(int id)
        {
            return _context.AddPersonalEvent.Any(e => e.Id == id);
        }
    }
}
