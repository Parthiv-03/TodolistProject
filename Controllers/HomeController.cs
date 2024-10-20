using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TodolistProject.Models;
using Microsoft.AspNetCore.Http; // For Session management

namespace TodolistProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); // This will return the login view
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(); // This will return the registration view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string username, string email, string password)
        {
            if (ModelState.IsValid)
            {
                // Hash the password
                var passwordHash = HashPassword(password);

                // Create new user
                var user = new User
                {
                    Username = username,
                    Email = email,
                    PasswordHash = passwordHash
                };

                // Save user to the database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                ViewBag.SuccessMessage = "Registration successful! You can now log in.";
            }
            return View(); // Return to registration view if model state is invalid
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Find user by username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Username);
                return RedirectToAction("Dashboard"); // Redirect to user dashboard or main page
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return View("Index"); // Return to login view if authentication fails
        }
        public IActionResult Dashboard()
        {
            // Retrieve the user ID from the session
            var userId = HttpContext.Session.GetInt32("UserId");
            var username = HttpContext.Session.GetString("UserName");
            if (userId == null)
            {
                return RedirectToAction("Index"); // Redirect to login if user ID is not found
            }

            // Fetch the logged-in user's To-Do lists
            var userWithToDoLists = _context.Users
                .Include(u => u.ToDoLists) // Include related ToDoLists
                .FirstOrDefault(u => u.Id == userId); // Get the specific user

            if (userWithToDoLists != null)
            {
                // Set the username from the session into the model
                userWithToDoLists.Username = username;
            }

            // Pass the user data to the view
            return View(userWithToDoLists);
        }

        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the login page
            return RedirectToAction("Index");
        }

        [Route("Home/Error")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode == 404)
                {
                    ViewBag.ErrorMessage = "Sorry, the page you requested could not be found.";
                }
                else
                {
                    ViewBag.ErrorMessage = "An unexpected error occurred.";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "An unexpected error occurred.";
            }
            return View();
        }

        // Helper method to hash passwords
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // Helper method to verify passwords
        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash;
        }


    }
}