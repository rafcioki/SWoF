using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.DomainObjects;
using BusinessLogic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RotaEntriesRepository : IRotaEntriesRepository
    {
        private readonly SupportWheelOfFateDbContext _dbContext;

        public RotaEntriesRepository(SupportWheelOfFateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<RotaEntry>> GetRotaEntries(DateTime from)
        {
            return await _dbContext
                .RotaEntries
                .Where(entry => entry.DateTime.Date >= from.Date)
                .Include(entry => entry.Engineer)
                .OrderBy(entry => entry.DateTime)
                .ToListAsync();
        }

        public async Task SaveRota(IList<RotaEntry> rota)
        {
            await _dbContext.RotaEntries.AddRangeAsync(rota);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRota()
        {
            await _dbContext.Database.ExecuteSqlCommandAsync("DELETE FROM [RotaEntries]");
        }
    }
}
