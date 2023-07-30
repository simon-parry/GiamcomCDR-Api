namespace GiacomCDR_Api.DataAccessLayer.CallDetailRecord
{
    public interface ICallDetailRecordRepository : IRepository<Models.CallDetailRecord>
    {
        decimal GetTotalCallCost();
        double GetAverageDuration();
        decimal GetAverageCost();

    }
}
