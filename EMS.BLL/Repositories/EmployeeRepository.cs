using EMS.BLL.Interfaces;
using EMS.DAL.Data.Contexts;
using EMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL.Repositories
{
    public class EmployeeRepository:GenericRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(ProjectContext context): base(context) { }

        public IEnumerable<Employee> GetByName(string name)
        {
            return _context.Employees.Where(e=>e.Name.ToLower().Contains(name.ToLower())).Include(e=>e.Department).ToList();
        }
        public override IEnumerable<Employee> GetAll()
        {
            return _context.Set<Employee>().Include(e=>e.Department).ToList();
        }
    }
}
