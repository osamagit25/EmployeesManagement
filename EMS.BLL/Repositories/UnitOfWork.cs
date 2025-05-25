using EMS.BLL.Interfaces;
using EMS.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _Context;
        private IDepartmentRepository _DepartmentRepository;
        private IEmployeeRepository _EmployeeRepository;
        public UnitOfWork(ProjectContext context)
        {
            _Context=context;
            _DepartmentRepository = new DepartmentRepository(context);
            _EmployeeRepository = new EmployeeRepository(context);

        }
        public IDepartmentRepository DepartmentRepository => _DepartmentRepository;

        public IEmployeeRepository EmployeeRepository => _EmployeeRepository;
    }
}
