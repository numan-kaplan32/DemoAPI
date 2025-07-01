using System.Threading.Tasks;
using Develop.Data.DbContextFolder;
using Develop.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace Develop.Service.Services
{
    public class UndependenciesQueries
    {
        private readonly APIDbContext _dbServices;

        public UndependenciesQueries(APIDbContext aPIDb)
        {
            _dbServices = aPIDb;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbServices.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
