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
    public class AddAssignment2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddAssignment2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddAssignment2
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddAssignment2.ToListAsync());
        }

        // GET: AddAssignment2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addAssignment2 = await _context.AddAssignment2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addAssignment2 == null)
            {
                return NotFound();
            }

            return View(addAssignment2);
        }

        // GET: AddAssignment2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddAssignment2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Class2,Event2,Difficulty2,Materials2,Description2,timeNeeded2,dateOfEvent2,dateChoice,timeChoice")] AddAssignment2 addAssignment2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addAssignment2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addAssignment2);
        }

        // GET: AddAssignment2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addAssignment2 = await _context.AddAssignment2.FindAsync(id);
            if (addAssignment2 == null)
            {
                return NotFound();
            }
            return View(addAssignment2);
        }

        // POST: AddAssignment2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Class2,Event2,Difficulty2,Materials2,Description2,timeNeeded2,dateOfEvent2,dateChoice,timeChoice")] AddAssignment2 addAssignment2)
        {
            if (id != addAssignment2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addAssignment2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddAssignment2Exists(addAssignment2.Id))
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
            return View(addAssignment2);
        }

        // GET: AddAssignment2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addAssignment2 = await _context.AddAssignment2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addAssignment2 == null)
            {
                return NotFound();
            }

            return View(addAssignment2);
        }

        // POST: AddAssignment2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addAssignment2 = await _context.AddAssignment2.FindAsync(id);
            _context.AddAssignment2.Remove(addAssignment2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddAssignment2Exists(int id)
        {
            return _context.AddAssignment2.Any(e => e.Id == id);
        }
    }
}
