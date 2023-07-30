using GiacomCDR_Api.DataAccessLayer.TestData;
using GiacomCDR_Api.Models;

namespace GiacomCDR_Api.Migrations
{

    public class SeedData
    {
        private readonly GiacomDbContext _dbContext;

        public SeedData(GiacomDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public void Seed()
        {
            foreach (var data in CDRTestData.TestData)
            {
                SeedTestRecords(data);
            }

            _dbContext.SaveChanges();
        }

        private void SeedTestRecords(CallDetailRecord callDetailRecord)
        {
            var exists = _dbContext.CallDetailRecords.Any(x => x.Id == callDetailRecord.Id);
            if (!exists)
            {
                _dbContext.CallDetailRecords.Add(callDetailRecord);
            }
            else
            {
                _dbContext.CallDetailRecords.Update(callDetailRecord);
            }
        }
    }

    
}
