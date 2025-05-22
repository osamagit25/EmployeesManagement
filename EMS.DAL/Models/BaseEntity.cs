using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.Models
{
   public class BaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [DisplayName("Date Of Creation")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime DateOfCreation { get; set; }
    }
}
