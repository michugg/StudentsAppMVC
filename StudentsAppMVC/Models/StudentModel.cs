using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static StudentsAppMVC.Data.MvcStudentContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsAppMVC.Models
{
    [Table("Students")]
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("Imie")]
        [Required(ErrorMessage = "Pole imie jest obowiązkowe")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Długosc imienia musi byc w zakresie 2 - 20")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Proszę podać poprawny adres email")]
        [Required(ErrorMessage = "Pole e-mail jest obowiązkowe")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Range(6, 100, ErrorMessage = "Podaj wiek w zakresie 6 - 100")]
        [Required(ErrorMessage = "Musisz podać wiek")]
        public int Age { get; set; }
        [DisplayName("Aktywny")]
        public bool IsActive { get; set; }
    }
}
