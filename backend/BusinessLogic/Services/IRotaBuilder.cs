using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.DomainObjects;

namespace BusinessLogic.Services
{
    public interface IRotaBuilder
    {
        Task<IList<RotaEntry>> BuildRota(DateTime to);
    }
}
