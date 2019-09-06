using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFAssignment.Models
{
    public class DepartmentDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [RegularExpression("^([a-zA-Z ]{3,})$", ErrorMessage = "Name contains only alphabets and at least 3 characters")]
        [MaxLength(30, ErrorMessage = "Name should contain only 30 characters")]
        public string Name { get; set; }

        public virtual ICollection<EmployeeDetails> EmployeeDetails { get; set; }
    }
}
