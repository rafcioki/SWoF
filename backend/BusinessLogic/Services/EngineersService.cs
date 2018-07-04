using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DomainObjects;
using MoreLinq.Extensions;
using static BusinessLogic.Constants.ConstantValues;

namespace BusinessLogic.Services
{
    public class EngineersService : IEngineersService
    {
        public IList<Engineer> GetAvailableEngineers(IList<Engineer> allEngineers,
            IList<RotaEntry> historyEntries)
        {
            if (historyEntries == null || historyEntries.Count == 0)
            {
                return allEngineers;
            }

            var lastDate = historyEntries.Last()?.DateTime;

            var yesterdaySupportEngineers = historyEntries
                .Where(entry => lastDate != null && entry.DateTime.Date == lastDate.Value)
                .Select(entry => entry.Engineer)
                .ToList();

            var lastTwoWeeksSupportEngineers = historyEntries
                .GroupBy(entry => entry.Engineer.Id,
                    entry => entry,
                    (id, historyEntry) =>
                    {
                        var enumerable = historyEntry.ToList();
                        return new
                        {
                            HistoryEntry = enumerable,
                            TotalHours = enumerable.Select(e => e.HoursInShift).Sum()
                        };
                    })
                .Where(groupedEntry => groupedEntry.TotalHours >= HoursInWorkDay)
                .SelectMany(groupedEntry => groupedEntry.HistoryEntry.Select(entry => entry.Engineer))
                .DistinctBy(engineer => engineer.Id);

            var notAvailableEngineers = lastTwoWeeksSupportEngineers
                .Concat(yesterdaySupportEngineers)
                .DistinctBy(engineer => engineer.Id)
                .ToList();

            return allEngineers
                    .Where(e => notAvailableEngineers.All(ue => ue.Id != e.Id))
                    .ToList();
        }
    }
}
