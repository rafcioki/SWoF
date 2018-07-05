using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.DomainObjects;

namespace BusinessLogic.Services
{
    public interface IRotaBuilder
    {
        /// <summary>
        /// Builds a new rota, from current day up to provided date.
        /// </summary>
        /// <param name="to">Date up to which schedule will be created.</param>
        /// <returns></returns>
        Task<IList<RotaEntry>> BuildRota(DateTime to);
    }
}
