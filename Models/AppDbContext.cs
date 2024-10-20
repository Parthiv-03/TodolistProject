using Microsoft.EntityFrameworkCore;

namespace TodolistProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}
