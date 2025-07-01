using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Develop.Core.CoreEntityFolder;
using Develop.Core.InterfaceCore;
using Develop.Data.DbContextFolder;
using Develop.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Develop.Service.Services
{
    public class Queries<T> : ICoreService<T> where T : CoreEntity
    {
        private readonly APIDbContext _service;
        public Queries(APIDbContext aPI)
        {
            _service = aPI;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _service.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _service.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                await _service.Set<T>().AddAsync(entity);
                return await SaveAsync();
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _service.Set<T>().Update(entity);
                return await SaveAsync();
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity == null) return false;
                _service.Set<T>().Remove(entity);
                return await SaveAsync();
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IQueryable<T> FilterData()
        {
            return _service.Set<T>().AsQueryable();
        }

        
        public async Task<bool> SaveAsync() => await _service.SaveChangesAsync() > 0;


    }
}

