using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        public string? FirstName { get; set; }

        [Required]
        public string? PasswordHashed { get; set; }

        [Required]
        public string? ConfirmedPassword { get; set; }
    }
}
