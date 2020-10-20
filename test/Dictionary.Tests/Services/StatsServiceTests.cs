using Dictionary.Database.Repositories.Stats;
using Dictionary.Services.Models.Stats;
using Dictionary.Services.Services.Stats;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace Dictionary.Tests.Services
{
    [TestFixture]
    public class StatsServiceTests
    {
        [Test]
        public void YearIsOutOfRange([Values(-20, 0, 2019, 2030)] int year)
        {
            var statsRepository = new Mock<IStatsRepository>();
            var statsService = new StatsService(statsRepository.Object, new ContributionYearValidator());
            Assert.ThrowsAsync<ValidationException>(async () => await statsService.GetContributionByYear(new ContributionYear(year)));
        }

        [Test]
        public void YearIsInRange([Values(null, 2020, 2029)] int year)
        {
            var statsRepository = new Mock<IStatsRepository>();
            var statsService = new StatsService(statsRepository.Object, new ContributionYearValidator());
            statsService.GetContributionByYear(new ContributionYear(year));
        }
    }
}