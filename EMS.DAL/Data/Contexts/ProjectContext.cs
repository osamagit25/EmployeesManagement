using EMS.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.Data.Contexts
{
    public class ProjectContext:IdentityDbContext<ApplicationUser>
    {
       
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
        
        
    }
}
