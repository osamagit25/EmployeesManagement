using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public bool IsAgree { get; set; }
        public DateTime DateOfCreation { get; set; }= DateTime.Now;


    }
}
