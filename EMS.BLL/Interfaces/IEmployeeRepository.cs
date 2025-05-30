﻿using EMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL.Interfaces
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
       Task< IEnumerable<Employee>> GetByNameAsync(string name);
    }
}
