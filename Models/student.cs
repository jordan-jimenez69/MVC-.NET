using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        public Major Major { get; set; }
    }

    public enum Major
    {
        IT,
        CA
    }
}
