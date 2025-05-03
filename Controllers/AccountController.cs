using Microsoft.AspNetCore.Mvc;
using GYM.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GYM.Controllers
{
    public class AccountController : Controller
    {
        private readonly GYMContext _context;

        public AccountController(GYMContext context)
        {
            _context = context;
        }

        public IActionResult AdminAccount(int id)
        {
            var admin = _context.Admin.FirstOrDefault(a => a.Id == id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin); // Return the admin details to the view
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string password, string role)
        {
            if (role == "Member")
            {
                var member = _context.Member.FirstOrDefault(m => m.email == email && m.password == password);
                if (member != null)
                {
                    //return RedirectToAction("Index", "Members"); //removed
                    return RedirectToAction("MemberDashboard", "Members", new { id = member.Id });
                }
            }
            else if (role == "Employee")
            {
                var employee = _context.Employee.FirstOrDefault(e => e.email == email && e.password == password);
                if (employee != null)
                {
                    //return RedirectToAction("Index", "Employees");  //removed
                    return RedirectToAction("EmployeeDashboard", "Employees", new { id = employee.Id });
                }
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        [HttpPost]
        public IActionResult Accounts(string email, string password, string role)
        {
            if (role == "Member")
            {
                var member = _context.Member.FirstOrDefault(m => m.email == email && m.password == password);
                if (member != null)
                {
                    return View("~/Views/Members/MemberDashboard.cshtml", member); // Pass member object
                }
            }
            else if (role == "Employee")
            {
                var employee = _context.Employee.FirstOrDefault(e => e.email == email && e.password == password);
                if (employee != null)
                {
                    return View("~/Views/Employees/EmployeeDashboard.cshtml", employee); // Pass employee object
                }
            }

            ViewBag.Error = "Invalid email, password, or role.";
            return View("Login");
        }

        // Optional: Add redirection after login - Removed
        //[HttpPost]
        //public IActionResult LoginRedirect(string role)
        //{
        //     switch (role)
        //     {
        //         case "Admin":
        //             return RedirectToAction("AdminAccount", "Account");
        //         case "Member":
        //             return RedirectToAction("Index", "Members");
        //         case "Employee":
        //             return RedirectToAction("Index", "Employees");
        //         default:
        //             return RedirectToAction("Login", "Home"); // or show an error
        //     }
        //}
    }
}

