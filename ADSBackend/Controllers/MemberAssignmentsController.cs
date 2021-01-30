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
    public class MemberAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemberAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MemberAssignments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MemberAssignment.Include(m => m.Assignment).Include(m => m.Member);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MemberAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberAssignment = await _context.MemberAssignment
                .Include(m => m.Assignment)
                .Include(m => m.Member)
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (memberAssignment == null)
            {
                return NotFound();
            }

            return View(memberAssignment);
        }

        // GET: MemberAssignments/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId");
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "Email");
            return View();
        }

        // POST: MemberAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,AssignmentId")] MemberAssignment memberAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", memberAssignment.AssignmentId);
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "Email", memberAssignment.MemberId);
            return View(memberAssignment);
        }

        // GET: MemberAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberAssignment = await _context.MemberAssignment.FindAsync(id);
            if (memberAssignment == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", memberAssignment.AssignmentId);
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "Email", memberAssignment.MemberId);
            return View(memberAssignment);
        }

        // POST: MemberAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,AssignmentId")] MemberAssignment memberAssignment)
        {
            if (id != memberAssignment.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberAssignmentExists(memberAssignment.MemberId))
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
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", memberAssignment.AssignmentId);
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "Email", memberAssignment.MemberId);
            return View(memberAssignment);
        }

        // GET: MemberAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberAssignment = await _context.MemberAssignment
                .Include(m => m.Assignment)
                .Include(m => m.Member)
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (memberAssignment == null)
            {
                return NotFound();
            }

            return View(memberAssignment);
        }

        // POST: MemberAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberAssignment = await _context.MemberAssignment.FindAsync(id);
            _context.MemberAssignment.Remove(memberAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberAssignmentExists(int id)
        {
            return _context.MemberAssignment.Any(e => e.MemberId == id);
        }
    }
}
