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

        public async Task< IEnumerable<Employee>> GetByNameAsync(string name)
        {
            return await _context.Employees.Where(e=>e.Name.ToLower().Contains(name.ToLower())).Include(e=>e.Department).ToListAsync();
        }
        public override async Task< IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Set<Employee>().Include(e=>e.Department).ToListAsync();
        }
    }
}
