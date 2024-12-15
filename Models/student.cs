using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Student : IdentityUser
    {
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "La spécialité est obligatoire.")]
        public Major Major { get; set; }
    }

    public enum Major
    {
        IT,
        CA
    }
}
