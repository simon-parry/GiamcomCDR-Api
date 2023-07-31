using GiacomCDR_Api.DataAccessLayer.CallDetailRecord;
using GiacomCDR_Api.DataAccessLayer.TestData;
using GiacomCDR_Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public Task ImportDataTest()
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));

            path = path + "\\TestData\\giamcom.csv";
            var result = _sut.ImportData(path);

            Assert.True(result);
            return Task.CompletedTask;
        }

        [Fact]
        public Task GetCallRecordsTest()
        {
            var result = _sut.GetCallRecords(DateTime.Parse("2023-06-16"), DateTime.Now);

            Assert.NotNull(result);
            Assert.True(result.ToList().Count == CDRTestData.TestData.Count);
            return Task.CompletedTask;
        }

        [Fact]
        public Task GetCallRecordsByCallerIdTest()
        {
            var result = _sut.GetCallRecordsByCallerId("01214477497");

            Assert.NotNull(result);
            Assert.True(result.ToList().Count == 3);
            return Task.CompletedTask;
        }

        [Fact]
        public Task DeleteCallRecordTest()
        {
            var id = new Guid("6DCCECC1-A7DA-4A8E-9777-CF519415BDD5");
            var result = _sut.DeleteCallRecord(id);

            Assert.True(result);
            return Task.CompletedTask;
        }
    }
}
