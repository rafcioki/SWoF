using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.DomainObjects;
using BusinessLogic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EngineerRepository : IEngineerRepository
    {
        private readonly SupportWheelOfFateDbContext _dbContext;

        public EngineerRepository(SupportWheelOfFateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Engineer>> GetEngineers()
        {
            return await _dbContext.Engineers.ToListAsync();
        }
    }
}
