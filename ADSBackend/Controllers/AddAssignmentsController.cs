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
    public class AddAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddAssignments
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddAssignment.ToListAsync());
        }

        // GET: AddAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addAssignment = await _context.AddAssignment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addAssignment == null)
            {
                return NotFound();
            }

            return View(addAssignment);
        }

        // GET: AddAssignments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Class,Event,Difficulty,Materials,Description,timeNeeded,dateOfEvent")] AddAssignment addAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addAssignment);
        }

        // GET: AddAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addAssignment = await _context.AddAssignment.FindAsync(id);
            if (addAssignment == null)
            {
                return NotFound();
            }
            return View(addAssignment);
        }

        // POST: AddAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Class,Event,Difficulty,Materials,Description,timeNeeded,dateOfEvent")] AddAssignment addAssignment)
        {
            if (id != addAssignment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddAssignmentExists(addAssignment.Id))
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
            return View(addAssignment);
        }

        // GET: AddAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addAssignment = await _context.AddAssignment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addAssignment == null)
            {
                return NotFound();
            }

            return View(addAssignment);
        }

        // POST: AddAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addAssignment = await _context.AddAssignment.FindAsync(id);
            _context.AddAssignment.Remove(addAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddAssignmentExists(int id)
        {
            return _context.AddAssignment.Any(e => e.Id == id);
        }
    }
}
