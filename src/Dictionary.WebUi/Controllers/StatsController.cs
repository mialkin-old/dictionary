using System.Threading.Tasks;
using Dictionary.Services.Models.Stats;
using Dictionary.Services.Services.Stats;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebUi.Controllers
{
    public class StatsController : Controller
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        public async Task<IActionResult> GetContributionByYear(int? year)
        {
            ContributionYearModel result = await _statsService.GetContributionByYear(new ContributionYearModel(year));
            return Ok(result);
        }
    }
}