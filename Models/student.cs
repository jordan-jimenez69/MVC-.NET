using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(50, ErrorMessage = "Le prénom ne doit pas dépasser 50 caractères.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "La spécialisation est requise.")]
        [EnumDataType(typeof(Major), ErrorMessage = "Veuillez sélectionner une spécialisation valide.")]
        [Display(Name = "Spécialisation")]
        public Major Major { get; set; }
    }

    public enum Major
    {
        [Display(Name = "Informatique")]
        IT,

        [Display(Name = "Comptabilité")]
        CA
    }
}
