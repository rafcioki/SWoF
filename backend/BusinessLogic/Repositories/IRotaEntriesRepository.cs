using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.DomainObjects;

namespace BusinessLogic.Repositories
{
    public interface IRotaEntriesRepository
    {
        Task<IList<RotaEntry>> GetRotaEntries(DateTime from);
        Task SaveRota(IList<RotaEntry> rota);
        Task DeleteRota();
    }
}
