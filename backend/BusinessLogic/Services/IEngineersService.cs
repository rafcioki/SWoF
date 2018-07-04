using System.Collections.Generic;
using BusinessLogic.DomainObjects;

namespace BusinessLogic.Services
{
    public interface IEngineersService
    {
        IList<Engineer> GetAvailableEngineers(IList<Engineer> allEngineers,
            IList<RotaEntry> historyEntries);
    }
}
