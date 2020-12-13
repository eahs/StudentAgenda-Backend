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
    public class AddEvent1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddEvent1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddEvent1
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddEvent.ToListAsync());
        }

        // GET: AddEvent1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addEvent1 = await _context.AddEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addEvent1 == null)
            {
                return NotFound();
            }

            return View(addEvent1);
        }

        // GET: AddEvent1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddEvent1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Event,Description,dateOfEvent")] AddEvent1 addEvent1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addEvent1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addEvent1);
        }

        // GET: AddEvent1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addEvent1 = await _context.AddEvent.FindAsync(id);
            if (addEvent1 == null)
            {
                return NotFound();
            }
            return View(addEvent1);
        }

        // POST: AddEvent1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Event,Description,dateOfEvent")] AddEvent1 addEvent1)
        {
            if (id != addEvent1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addEvent1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddEvent1Exists(addEvent1.Id))
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
            return View(addEvent1);
        }

        // GET: AddEvent1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addEvent1 = await _context.AddEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addEvent1 == null)
            {
                return NotFound();
            }

            return View(addEvent1);
        }

        // POST: AddEvent1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addEvent1 = await _context.AddEvent.FindAsync(id);
            _context.AddEvent.Remove(addEvent1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddEvent1Exists(int id)
        {
            return _context.AddEvent.Any(e => e.Id == id);
        }
    }
}
