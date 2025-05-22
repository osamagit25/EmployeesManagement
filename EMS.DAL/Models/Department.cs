using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.Models
{
   public class Department:BaseEntity
    {
       
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        public ICollection<Employee>? Employees { get; set; }


    }
}
