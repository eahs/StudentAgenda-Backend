using ADSBackend.Data;
using ADSBackend.Models.Identity;
using ADSBackend.Models.AdminViewModels;
using ADSBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ADSBackend.Models;
using System.Collections.Generic;

namespace ADSBackend.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.OrderBy(x => x.LastName).ToListAsync();

            var viewModel = users.Select(x => new UserViewModel
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Role = _userManager.GetRolesAsync(x).Result.FirstOrDefault()
            }).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,FirstName,LastName,Role,Password,ConfirmPassword")] UserViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Password))
            {
                ModelState.AddModelError("Password", "Password is required when creating a user");
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                };

                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, viewModel.Password);

                // create user
                await _userManager.CreateAsync(user);

                // assign new role
                await _userManager.AddToRoleAsync(user, viewModel.Role);

                // send confirmation email
                var confirmationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.EmailConfirmationLink(user.Id, confirmationCode, Request.Scheme);
                await _emailSender.SendEmailConfirmationAsync(viewModel.Email, confirmationLink);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var role = await _userManager.GetRolesAsync(user);

            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = role.FirstOrDefault()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,FirstName,LastName,Role,Password,ConfirmPassword")] UserViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _context.Users.FindAsync(id);

                    user.Email = viewModel.Email;
                    user.FirstName = viewModel.FirstName;
                    user.LastName = viewModel.LastName;

                    if (!string.IsNullOrEmpty(viewModel.Password))
                    {
                        // change the password
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, viewModel.Password);
                    }

                    // upadate user
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    // reset user roles
                    var roles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, roles);

                    // assign new role
                    await _userManager.AddToRoleAsync(user, viewModel.Role);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(viewModel.Id))
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

            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var role = await _userManager.GetRolesAsync(user);

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = role.FirstOrDefault()
            };

            return View(viewModel);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var role = await _userManager.GetRolesAsync(user);

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = role.FirstOrDefault()
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }


/*
date to string:

DateTime date = DateTime.Now; // will give the date for today
string dateWithFormat = date.ToLongDateString();
*/
        [HttpPost]
        public async Task<IActionResult> UpdateAssignment(int id, [Bind("Event, DateOfEvent, TimeChoice, DateChoice")] Assignment assignment)
        {
            //this needs a for each loop to loop through each entry on the assignments model so that it goes through each and adds it to UserAssignments.cs and for it to check for new entries, then get displayed on the user view model

            List<UserAssignments> Ua = new List<UserAssignments>();
            var AsList = new UserAssignments();


            var Name = assignment.Event;

            AsList.AssignmentName = Name;


            var dd = assignment.DateOfEvent;

            string ddS;

            if (dd != null)
            { 
                ddS = dd.ToLongDateString();
                AsList.AssignmentDD = ddS;
            }

            //time choice - added s means string

            var tc = assignment.TimeChoice;
            string tcS;

            if (tc != null)
            {
                tcS = tc + "";

                tcS = ((System.DateTime)tc).ToLongTimeString();

                AsList.timeChoice = tcS;

            }
            //optional date
            var op = assignment.DateChoice;

            string opS;

            if (op != null)
            {
                opS = ((System.DateTime)op).ToLongDateString();

                AsList.optionalDate = opS;
            }

            
            Ua.Add(AsList);

            return View(Ua);
        }



    private bool UserExists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }





    }
}