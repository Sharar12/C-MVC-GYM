using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GYM.Data;
using GYM.Models;

namespace GYM.Controllers
{
    public class MembersController : Controller
    {
        private readonly GYMContext _context;

        public MembersController(GYMContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _context.Member.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }



        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,email,password,gender,Address,phone,age,weight,height,package,paymentMethod,Class,Schedule,CreditCardNumber,Tid,amount,Expire")] Member member)
        {
            if (ModelState.IsValid)
            {
                // Set amount based on the selected package
                switch (member.package)
                {
                    case "Basic":
                        member.amount = 1000;
                        // Set expiration date for Basic (1 month from today)
                        member.Expire = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                        break;
                    case "Premium":
                        member.amount = 5000;
                        // Set expiration date for Premium (6 months from today)
                        member.Expire = DateTime.Now.AddMonths(6).ToString("yyyy-MM-dd");
                        break;
                    case "Gold":
                        member.amount = 9000;
                        // Set expiration date for Gold (1 year from today)
                        member.Expire = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
                        break;
                    default:
                        member.amount = 0; // Default case if no valid package is selected
                        break;
                }

                // Generate a new GUID for Tid
                member.Tid = Guid.NewGuid().ToString();

                // Add the new member to the context
                _context.Add(member);
                await _context.SaveChangesAsync();

                // Redirect to the Index page (or any other page you wish to redirect to after successful signup)
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, return the form with the member data
            return View(member);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(Member member)
        {
            if (ModelState.IsValid)
            {
                // Set the amount based on the selected package
                switch (member.package)
                {
                    case "Basic":
                        member.amount = 1000;
                        // Set Expire date for Basic (1 month from today)
                        member.Expire = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                        break;
                    case "Premium":
                        member.amount = 5000;
                        // Set Expire date for Premium (6 months from today)
                        member.Expire = DateTime.Now.AddMonths(6).ToString("yyyy-MM-dd");
                        break;
                    case "Gold":
                        member.amount = 9000;
                        // Set Expire date for Gold (1 year from today)
                        member.Expire = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
                        break;
                    default:
                        member.amount = 0; // Default case if no valid package is selected
                        break;
                }

                // Generate a new GUID for transactionId
                member.Tid = Guid.NewGuid().ToString();

                // Add the member to the context
                _context.Add(member);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // 👉 Redirect to Login Page after signup
                return RedirectToAction("Login", "Account");
            }

            // If validation fails, stay on the form
            return View(member);
        }




        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,email,password,gender,Address,phone,age,weight,height,package,paymentMethod,Class,Schedule,CreditCardNumber,Tid,amount,Expire")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/EditMember/5

        public async Task<IActionResult> EditMember(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View("EditMember", member); // Ensure the correct view name is used
        }


        // POST: Members/EditMember/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMember(int id, [Bind("Id,name,email,password,gender,Address,phone,age,weight,height,package,paymentMethod,Class,Schedule,CreditCardNumber,Tid,amount,Expire")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Redirect to the MemberDashboard action, not Index
                return RedirectToAction("MemberDashboard", new { id = id });
            }
            return View(member);
        }


        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            if (member != null)
            {
                _context.Member.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.Id == id);
        }

        // GET: Members/MemberDashboard/5
        public async Task<IActionResult> MemberDashboard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View("MemberDashboard", member);
        }

        // GET: Members/ViewMembers
        public async Task<IActionResult> ViewMembers()
        {
            // Retrieve all members from the database
            var members = await _context.Member.ToListAsync();
            // Pass the list of members to the view
            return View("ViewMembers", members);
        }

        // GET: Members/AssignClassSchedule/5
        public async Task<IActionResult> AssignClassSchedule(int? memberId)
        {
            if (memberId == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(memberId);
            if (member == null)
            {
                return NotFound();
            }

            // You might want to pass a list of available classes and schedules to the view
            // to populate dropdowns or other UI elements.  For now, I'm just passing the member.
            return View("AssignClassSchedule", member);
        }

        // POST: Members/AssignClassSchedule/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignClassSchedule(int Id, string Class, string Schedule)
        {
            var member = await _context.Member.FindAsync(Id);
            if (member == null)
            {
                return NotFound();
            }

            member.Class = Class;
            member.Schedule = Schedule;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ViewMembers","Employees"); // Redirect back to ViewMembers
            }
            // If ModelState is not valid, return to the AssignClassSchedule view with the member data
            return View("AssignClassSchedule", member);
        }
    }
}
