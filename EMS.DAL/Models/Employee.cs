﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.Models
{
    public class Employee:BaseEntity
    {
       
        public int Age { get; set; }
        
        
        public decimal Salary { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
       
        public string Address { get; set; }
        
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
