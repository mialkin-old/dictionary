using System;
using Dictionary.Database.Repositories.Stats;
using Dictionary.Services.CustomExceptions;
using Dictionary.Services.Services.Stats;
using Dictionary.Services.Validators;
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
            var statsService = new StatsService(statsRepository.Object, new StatsValidator());
            Assert.ThrowsAsync<CustomValidationException>(async () => await statsService.GetContributionByYear(year));
        }

        [Test]
        public void YearIsInRange([Values(null, 2020, 2029)] int year)
        {
            var statsRepository = new Mock<IStatsRepository>();
            var statsService = new StatsService(statsRepository.Object, new StatsValidator());
            statsService.GetContributionByYear(year);
        }
    }
}