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
        [DisplayName("ID Studenta")]
        public int StudentId { get; set; }
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Proszę podać poprawny adres email")]
        [Required(ErrorMessage = "Pole e-mail jest obowiązkowe")]
        [DisplayName("Email")]
     
       
        public string Email { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
