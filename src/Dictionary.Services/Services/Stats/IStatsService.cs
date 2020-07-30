using System.Threading.Tasks;
using Dictionary.Services.Models.Stats;

namespace Dictionary.Services.Services.Stats
{
    public interface IStatsService
    {
        Task<ContributionByYearVm> GetContributionByYear(int? year);
    }
}
