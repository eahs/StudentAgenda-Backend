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
    public class UserNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserNotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserNotes.ToListAsync());
        }

        // GET: UserNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userNotes = await _context.UserNotes
                .FirstOrDefaultAsync(m => m.UserNotesId == id);
            if (userNotes == null)
            {
                return NotFound();
            }

            return View(userNotes);
        }

        // GET: UserNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserNotesId,noteName,noteContent")] UserNotes userNotes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userNotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userNotes);
        }

        // GET: UserNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userNotes = await _context.UserNotes.FindAsync(id);
            if (userNotes == null)
            {
                return NotFound();
            }
            return View(userNotes);
        }

        // POST: UserNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserNotesId,noteName,noteContent")] UserNotes userNotes)
        {
            if (id != userNotes.UserNotesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userNotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserNotesExists(userNotes.UserNotesId))
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
            return View(userNotes);
        }

        // GET: UserNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userNotes = await _context.UserNotes
                .FirstOrDefaultAsync(m => m.UserNotesId == id);
            if (userNotes == null)
            {
                return NotFound();
            }

            return View(userNotes);
        }

        // POST: UserNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userNotes = await _context.UserNotes.FindAsync(id);
            _context.UserNotes.Remove(userNotes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserNotesExists(int id)
        {
            return _context.UserNotes.Any(e => e.UserNotesId == id);
        }
    }
}
