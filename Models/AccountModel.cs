using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le prénom ne doit pas dépasser 50 caractères.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Le mot de passe doit comporter entre {2} et {1} caractères.", MinimumLength = 6)]
        public string? PasswordHashed { get; set; }

        [Required(ErrorMessage = "La confirmation du mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        [Compare("PasswordHashed", ErrorMessage = "Le mot de passe et sa confirmation ne correspondent pas.")]
        [Display(Name = "Confirmer le mot de passe")]
        public string? ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Le rôle est obligatoire.")]
        [Display(Name = "Rôle")]
        public RoleType Role { get; set; } // Ajout de la propriété Role
    }

    public enum RoleType
    {
        Teacher,
        Student
    }
}
