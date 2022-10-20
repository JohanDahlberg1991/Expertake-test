
using Data.Service;
using Data.Service.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DataUnitTest
{
    public class LatencyServiceTest
    {
        private readonly ILatencyService _sut;

        public LatencyServiceTest()
        {
            _sut = new LatencyService();
        }

        [Fact]
        public async Task GetDataFromGetLatencyTestResultTest()
        {

            DateTime testStartDate = DateTime.Parse("2021-08-20");
            DateTime testEndDate = testStartDate.AddDays(3);

            var periodPropForCheck = new List<string> { testStartDate.ToString("yyyy-MM-dd"), testEndDate.ToString("yyyy-MM-dd") };

            var result = await _sut.GetLatencyResult(testStartDate, testEndDate);

            Assert.True(testStartDate == result.StartDate);
            Assert.True(testEndDate == result.EndDate);
            Assert.True(periodPropForCheck[0] == result.Period[0]);
            Assert.True(periodPropForCheck[1] == result.Period[1]);
            Assert.True(result.AverageLatancies.Count > 0);
            Assert.True(result.AverageLatancies.Count == result.AverageLatancies.Select(al => al.ServiceId).Distinct().Count());
        }

        [Fact]
        public async Task GetLatencyTestResultIfDatesAreSameTest()
        {
            DateTime testStartDate = DateTime.Parse("2021-08-20");

            var periodPropForCheck = new List<string> { testStartDate.ToString("yyyy-MM-dd"), testStartDate.ToString("yyyy-MM-dd") };

            var result = await _sut.GetLatencyResult(testStartDate, testStartDate);

            Assert.True(testStartDate == result.StartDate);
            Assert.True(testStartDate == result.EndDate);
            Assert.True(periodPropForCheck[0] == result.Period[0]);
            Assert.True(periodPropForCheck[1] == result.Period[1]);
            Assert.True(result.AverageLatancies.Count > 0);
            Assert.True(result.AverageLatancies.Count == result.AverageLatancies.Select(al => al.ServiceId).Distinct().Count());
        }

        //TODO add tests to check if errors uccurs correctly
    }
}