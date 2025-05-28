using EMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL.Interfaces
{
    public interface   IGenericRepository<T>
    {
      Task<  IEnumerable<T>> GetAllAsync();
       Task <T> GetById(int? id);
        
      Task<  int> AddAsync(T entity);
        Task<int> Update(T entity);    
        Task< int >Delete(T entity);
    }
}
