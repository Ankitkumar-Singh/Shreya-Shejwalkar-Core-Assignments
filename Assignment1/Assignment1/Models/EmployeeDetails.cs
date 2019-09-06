using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class EmployeeDetails
    {
        public enum GenderType
        {
            Female,
            Male
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [RegularExpression("^([a-zA-Z ]{3,})$", ErrorMessage = "Name contains only alphabets and at least 3 characters")]
        [MaxLength(30, ErrorMessage = "Name should contain only 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public GenderType SelectedGenderType { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please check the checkbox")]
        public bool AcceptsTerms { get; set; }

        [Required(ErrorMessage = "Please select Department")]
        public Departments? Department { get; set; }

        [Required(ErrorMessage = "Address cannot be empty")]
        [RegularExpression("^([A-Za-z0-9, ]{3,})$", ErrorMessage = "Address contains alphabets, numbers and (,) and at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Address should contain only 100 characters")]
        public string Address { get; set; }
    }
}
