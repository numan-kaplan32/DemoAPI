using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Develop.Core.CoreEntityFolder;

namespace Develop.Core.InterfaceCore
{
   public interface ICoreService<T> where T : CoreEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        IQueryable<T> FilterData();
        Task<bool> SaveAsync();
    }
}
