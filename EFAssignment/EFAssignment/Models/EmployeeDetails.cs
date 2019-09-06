using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFAssignment.Models
{
    public class EmployeeDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [RegularExpression("^([a-zA-Z ]{3,})$", ErrorMessage = "Name contains only alphabets and at least 3 characters")]
        [MaxLength(30, ErrorMessage = "Name should contain only 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual DepartmentDetails DepartmentDetails { get ; set;}
    }
}
 