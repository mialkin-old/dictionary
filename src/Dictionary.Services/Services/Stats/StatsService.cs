using System.Threading.Tasks;
using Dictionary.Database.Repositories.Stats;
using Dictionary.Services.Models.Stats;
using FluentValidation;

namespace Dictionary.Services.Services.Stats
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _statsRepository;
        private readonly ContributionYearValidator _contributionYearValidator;

        public StatsService(IStatsRepository statsRepository, ContributionYearValidator contributionYearValidator)
        {
            _statsRepository = statsRepository;
            _contributionYearValidator = contributionYearValidator;
        }

        public async Task<ContributionYear> GetContributionByYear(ContributionYear model)
        {
            await _contributionYearValidator.ValidateAndThrowAsync(model);

            return model;
        }
    }
}