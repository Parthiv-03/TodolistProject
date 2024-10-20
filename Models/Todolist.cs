using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodolistProject.Models
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [StringLength(200)]
        public string Title { get; set; } // Task title

        [StringLength(1000)]
        public string Description { get; set; } // Task description (optional)

        public bool IsCompleted { get; set; } // Status of the task

        [Required]
        public DateTime DueDate { get; set; } // Due date for the task

        // Foreign key to User
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; } // Navigation property
    }
}
