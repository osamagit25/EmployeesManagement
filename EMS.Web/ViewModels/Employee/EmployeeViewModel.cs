using EMS.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EMS.Web.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age must be 18:60")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Phone]
        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("Phone number ")]
        public string PhoneNumber { get; set; }
        [RegularExpression(@"^\d{1,5}\s[A-Za-z\s]+-[A-Za-z\s]+-[A-Za-z\s]+$",
     ErrorMessage = "Address must be like 123 Street-City-Country")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [DisplayName("Is active")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
        public int? DepartmentId { get; set; }

        public string DepartmentName { get; set; }

    }
}
