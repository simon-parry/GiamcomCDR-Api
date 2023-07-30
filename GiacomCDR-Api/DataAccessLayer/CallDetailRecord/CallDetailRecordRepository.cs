namespace GiacomCDR_Api.DataAccessLayer.CallDetailRecord
{
    public class CallDetailRecordRepository : Repository<Models.CallDetailRecord>, ICallDetailRecordRepository
    {
        protected readonly GiacomDbContext _callDetailDbContext;

        public CallDetailRecordRepository(GiacomDbContext callDetailDbContext) : base(callDetailDbContext)
        {
            _callDetailDbContext = callDetailDbContext;
        }

        public decimal GetTotalCallCost()
        {
            var total = _callDetailDbContext.CallDetailRecords.Sum(i => i.Cost);
            return total;
        }

        public double GetAverageDuration()
        {
            var total = _callDetailDbContext.CallDetailRecords.Average(i => i.Duration);
            return total;
        }

        public decimal GetAverageCost()
        {
            var total = _callDetailDbContext.CallDetailRecords.Average(i => i.Cost);
            return total;
        }        
    }
}
