using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.DomainObjects;
using BusinessLogic.Repositories;
using Core.Extensions;
using Core.Services;
using static BusinessLogic.Constants.ConstantValues;

namespace BusinessLogic.Services
{
    public class RotaBuilder : IRotaBuilder
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IEngineerRepository _engineerRepository;
        private readonly IRandomService _randomService;
        private readonly IEngineersService _engineersService;

        public RotaBuilder(IDateTimeProvider dateTimeProvider,
            IEngineerRepository engineerRepository,
            IRandomService randomService,
            IEngineersService engineersService)
        {
            _dateTimeProvider = dateTimeProvider;
            _engineerRepository = engineerRepository;
            _randomService = randomService;
            _engineersService = engineersService;
        }

        public async Task<IList<RotaEntry>> BuildRota(DateTime endDate)
        {
            var allEngineers = await _engineerRepository.GetEngineers();

            if (allEngineers?.Count == 0)
            {
                return new List<RotaEntry>();
            }

            var rota = new List<RotaEntry>();
            var startDate = _dateTimeProvider.Now;

            foreach (var day in startDate.EachDay(endDate))
            {
                if (day.IsWeekend())
                {
                    continue;
                }

                var lastPeriodRota = rota.Where(entry =>
                    entry.DateTime > day.AddDays(-SupportPeriodInDays))
                    .ToList();

                var availableEngineers =
                    _engineersService.GetAvailableEngineers(allEngineers, lastPeriodRota);

                // Handles an edge case where on rare cases algorithm failed to fill the schedule - 
                // f.e. when the same engineer is left for the last two spots. One possible fix would be
                // to apply genetic algorithms instead.
                if (availableEngineers.Count < SupportingEngineersPerDay)
                {
                    return await BuildRota(endDate);
                }

                var randomIndexes = _randomService.GetDifferentNumbersFromRange(0,
                    availableEngineers.Count - 1,
                    SupportingEngineersPerDay);

                rota.AddRange(randomIndexes.Select(index => new RotaEntry
                {
                    DateTime = day,
                    Engineer = availableEngineers[index],
                    HoursInShift = HoursInDailySupport
                }));
            }

            return rota;
        }
    }
}
