using EMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.Data.Configrations
{
    class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(10);
            
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(d => d.DateOfCreation)
                .IsRequired();
        }
    }
}
