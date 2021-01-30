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
    public class PersonalEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalEvent.ToListAsync());
        }

        // GET: PersonalEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalEvent = await _context.PersonalEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalEvent == null)
            {
                return NotFound();
            }

            return View(personalEvent);
        }

        // GET: PersonalEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PNameOfEvent,DateOfEvent,PTimeOfEvent,PTimeNeeded,Pdescription")] PersonalEvent personalEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalEvent);
        }

        // GET: PersonalEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalEvent = await _context.PersonalEvent.FindAsync(id);
            if (personalEvent == null)
            {
                return NotFound();
            }
            return View(personalEvent);
        }

        // POST: PersonalEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PNameOfEvent,DateOfEvent,PTimeOfEvent,PTimeNeeded,Pdescription")] PersonalEvent personalEvent)
        {
            if (id != personalEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalEventExists(personalEvent.Id))
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
            return View(personalEvent);
        }

        // GET: PersonalEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalEvent = await _context.PersonalEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalEvent == null)
            {
                return NotFound();
            }

            return View(personalEvent);
        }

        // POST: PersonalEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalEvent = await _context.PersonalEvent.FindAsync(id);
            _context.PersonalEvent.Remove(personalEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalEventExists(int id)
        {
            return _context.PersonalEvent.Any(e => e.Id == id);
        }
    }
}
