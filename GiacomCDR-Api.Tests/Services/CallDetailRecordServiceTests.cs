using GiacomCDR_Api.DataAccessLayer.CallDetailRecord;
using GiacomCDR_Api.DataAccessLayer.TestData;
using GiacomCDR_Api.Services;
using Microsoft.EntityFrameworkCore;

namespace GiacomCDR_Api.Tests.Services
{
    public class CallDetailRecordServiceTests
    {

        private readonly CallDetailRecordService _sut;
        private Guid _id;

        public CallDetailRecordServiceTests()
        {
            var options = new DbContextOptionsBuilder<GiacomDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new GiacomDbContext(options);

            var repo = new CallDetailRecordRepository(dbContext);

            _sut = new CallDetailRecordService(repo);

            foreach (var data in CDRTestData.TestData)
            {
                dbContext.CallDetailRecords.Add(data);
            }

            dbContext.SaveChanges();
        }

        [Fact]
        public Task GetCallRecordsTest()
        {
            var result = _sut.GetCallRecords(DateTime.Parse("2023-06-16"), DateTime.Now);

            Assert.NotNull(result);
            Assert.True(result.ToList().Count == CDRTestData.TestData.Count);
            return Task.CompletedTask;
        }

        //[Fact]
        //public Task GetTotalCallCostTest()
        //{
        //    var result = _sut.GetTotalCallCost();

        //    Assert.Equal(1.82m, result);
        //    return Task.CompletedTask;
        //}

        //[Fact]
        //public Task GetAverageDurationTest()
        //{
        //    var result = _sut.GetAverageDuration();

        //    Assert.Equal(93.66666666666667, result);
        //    return Task.CompletedTask;
        //}

        //[Fact]
        //public Task GetAverageCostTest()
        //{
        //    var result = _sut.GetAverageCost();

        //    Assert.Equal(0.6066666666666666666666666667m, result);
        //    return Task.CompletedTask;
        //}
    }
}
