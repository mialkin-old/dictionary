using System.Threading.Tasks;
using Dictionary.Database.Repositories.Stats;
using Dictionary.Services.Models.Stats;
using Dictionary.Services.Validators;
using FluentValidation;

namespace Dictionary.Services.Services.Stats
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _statsRepository;
        private readonly StatsValidator _statsValidator;

        public StatsService(IStatsRepository statsRepository, StatsValidator statsValidator)
        {
            _statsRepository = statsRepository;
            _statsValidator = statsValidator;
        }

        public async Task<ContributionByYearVm> GetContributionByYear(int? year)
        {
            await _statsValidator.ValidateAndThrowAsync(year);

            return new ContributionByYearVm();
        }
    }
}
