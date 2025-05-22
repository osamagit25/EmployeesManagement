using EMS.BLL.Interfaces;
using EMS.DAL.Data.Contexts;
using EMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
      public DepartmentRepository(ProjectContext context) : base(context) { }
    }
}
