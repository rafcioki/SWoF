using System.Collections.Generic;
using BusinessLogic.DomainObjects;

namespace BusinessLogic.Services
{
    public interface IEngineersService
    {
        /// <summary>
        /// Returns a list of available engineers, i.e. engineers that can be assigned for support.
        /// </summary>
        /// <param name="allEngineers">All available engineers.</param>
        /// <param name="historyEntries">Schedule so far.</param>
        /// <returns></returns>
        IList<Engineer> GetAvailableEngineers(IList<Engineer> allEngineers,
            IList<RotaEntry> historyEntries);
    }
}
