using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{

    public class Teacher : IdentityUser
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? FirstName { get; set; }
    }
}
