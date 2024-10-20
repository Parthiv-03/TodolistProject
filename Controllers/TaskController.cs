using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodolistProject.Models;

namespace TodolistProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        // Action to display the user's To-Do list
        public async Task<IActionResult> Dashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Home"); // Redirect to login if user ID is not found
            }

            var user = await _context.Users
                .Include(u => u.ToDoLists) // Include ToDoLists to get the user's tasks
                .FirstOrDefaultAsync(u => u.Id == userId.Value);

            return View(user); // Pass the user model with ToDoLists to the view
        }

        // Action to show the Add Task form
        [HttpGet]
        public IActionResult AddTask()
        {
            return View(); // Return the view for adding a new task
        }

        // Action to handle the form submission for adding a task
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTask(string title, string description, DateTime dueDate)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Home"); // Redirect to login if user ID is not found
            }

            // Create a new ToDoList item
            var todo = new ToDoList
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                IsCompleted = false, // Default to not completed
                UserId = userId.Value // Set the UserId to the currently logged-in user's ID
            };

            // Save the new task to the database
            _context.ToDoLists.Add(todo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard", "Home"); // Redirect back to the dashboard
        }

        [HttpGet]
        public async Task<IActionResult> EditTask(int id)
        {
            var task = await _context.ToDoLists.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTask(ToDoList updatedTask)
        {
            var task = await _context.ToDoLists.FindAsync(updatedTask.Id);

            if (task == null)
            {
                return NotFound();
            }

            // If the task is marked as completed, delete it from the database
            if (updatedTask.IsCompleted)
            {
                _context.ToDoLists.Remove(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Home"); // Redirect to dashboard
            }

            // Otherwise, update the task details
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;
            task.IsCompleted = updatedTask.IsCompleted;

            _context.ToDoLists.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard", "Home"); // Redirect to dashboard
        }
    }
}