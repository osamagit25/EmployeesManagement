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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private protected readonly ProjectContext _context;
        public GenericRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task< int> AddAsync(T entity)
        {
          await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual  async Task <IEnumerable<T> > GetAllAsync()
        {
           return await  _context.Set<T>().ToListAsync();
        }

        public async Task< T> GetById(int? id)
        {
           
           return await _context.Set<T>().FindAsync(id);
           
        }

        public async Task<int> Update(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
