using System;
using System.Threading.Tasks;
using Dictionary.Database.Repositories.Stats;
using Dictionary.Services.Models.Stats;

namespace Dictionary.Services.Services.Stats
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _statsRepository;

        public StatsService(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        public Task<ContributionByYearVm> GetContributionByYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
