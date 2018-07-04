using System.Collections.Generic;

namespace Core.Services
{
    public interface IRandomService
    {
        int GetNumberBetween(int min, int max);

        IList<int> GetDifferentNumbersFromRange(int min, int max, int howMany);
    }
}
