using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.DomainObjects;

namespace BusinessLogic.Repositories
{
    public interface IEngineerRepository
    {
        Task<IList<Engineer>> GetEngineers();
    }
}
