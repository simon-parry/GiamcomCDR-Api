using GiacomCDR_Api.Models;

namespace GiacomCDR_Api.Services
{
    public interface ICallDetailRecordService
    {
        IEnumerable<CallDetailRecord> GetCallRecords(DateTime startDate, DateTime endDate);
        IEnumerable<CallDetailRecord> GetCallRecordsByCallerId(string callerId);
        void DeleteCallRecord(Guid id);
        bool ImportData(string FileName);
        CallerTotals GetCallerTotals(string caller_id);
    }
}
