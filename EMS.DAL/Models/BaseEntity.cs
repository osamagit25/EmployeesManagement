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

        
        public string Name { get; set; }
        
        public DateTime DateOfCreation { get; set; }
    }
}
