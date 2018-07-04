using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class RandomService : IRandomService
    {
        public int GetNumberBetween(int min, int max)
        {
            return new Random().Next(min, max + 1);
        }

        public IList<int> GetDifferentNumbersFromRange(int min, int max, int howMany)
        {
            var numbers = new List<int>();

            if (min > max)
            {
                throw new ArgumentException("Min value cannot be greater than max.");
            }

            while (numbers.Count < howMany)
            {
                int randomNumber = GetNumberBetween(min, max);

                if (!numbers.Contains(randomNumber))
                {
                    numbers.Add(randomNumber);
                }
            }

            return numbers;
        }
    }
}
