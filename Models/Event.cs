using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le titre ne doit pas dépasser 100 caractères.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "La description est obligatoire.")]
        [StringLength(500, ErrorMessage = "La description ne doit pas dépasser 500 caractères.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "La date est obligatoire.")]
        [DataType(DataType.Date, ErrorMessage = "La date n'est pas valide.")]
        [FutureDate(ErrorMessage = "La date de l'événement doit être dans le futur.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Le lieu est obligatoire.")]
        [StringLength(200, ErrorMessage = "Le lieu ne doit pas dépasser 200 caractères.")]
        public string? Location { get; set; }
    }

    // Validation pour s'assurer que la date est dans le futur
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }
}
