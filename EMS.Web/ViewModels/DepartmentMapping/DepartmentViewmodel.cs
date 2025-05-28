using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMS.Web.ViewModels
{
    public class DepartmentViewmodel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [DisplayName("Date Of Creation")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime DateOfCreation { get; set; }
       
    }
}
