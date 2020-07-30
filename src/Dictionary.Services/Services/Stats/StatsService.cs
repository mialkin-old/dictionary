using System.Threading.Tasks;
using Dictionary.Database.Repositories.Stats;
using Dictionary.Services.Models.Stats;
using FluentValidation;

namespace Dictionary.Services.Services.Stats
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _statsRepository;
        private readonly ContributionYearModelValidator _contributionYearModelValidator;

        public StatsService(IStatsRepository statsRepository,
            ContributionYearModelValidator contributionYearModelValidator)
        {
            _statsRepository = statsRepository;
            _contributionYearModelValidator = contributionYearModelValidator;
        }

        public async Task<ContributionYearModel> GetContributionByYear(ContributionYearModel model)
        {
            await _contributionYearModelValidator.ValidateAndThrowAsync(model);

            return model;
        }
    }
}