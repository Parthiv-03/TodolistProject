using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodolistProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Store password as a hashed value

        // Navigation property for related ToDoLists
        public ICollection<ToDoList> ToDoLists { get; set; }
    }
}