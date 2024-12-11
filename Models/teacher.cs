using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public enum Subject
    {
        Mathematics,
        ComputerScience,
        Physics,
        Chemistry
    }

    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public int Age { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }

        [Required]
        public Subject Subject { get; set; }
    }
}
