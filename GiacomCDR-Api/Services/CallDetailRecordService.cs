
using CsvHelper.Configuration;
using CsvHelper;
using GiacomCDR_Api.DataAccessLayer.CallDetailRecord;
using GiacomCDR_Api.Models;
using System.Globalization;

namespace GiacomCDR_Api.Services
{
        public class CallDetailRecordService : ICallDetailRecordService
    {
        private readonly ICallDetailRecordRepository _callDetailRecordRepository;
        public CallDetailRecordService(ICallDetailRecordRepository callDetailRecordRepository) 
        {
            _callDetailRecordRepository = callDetailRecordRepository;
        }
        public bool ImportData(string FileName)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                };

                using (var reader = new StreamReader(FileName))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<CsvRowMap>();
                    var records = csv.GetRecords<CsvRow>().Select(row => new CallDetailRecord()
                    {
                        CallerId = row.caller_id,
                        Recipient = row.recipient,
                        CallDate = row.call_date,
                        EndTime = row.end_time.ToString(),
                        Duration = row.duration,
                        Cost = row.cost,
                        Reference = row.reference,
                        Currency = row.currency
                    });

                    var items = records.ToList();
                    _callDetailRecordRepository.AddRange(items);  //change to Add bulk
                }
            }
            catch (Exception ex)
            {
                return false;
            } 

            return true;
        }

        public IEnumerable<CallDetailRecord> GetCallRecords(DateTime startDate, DateTime endDate)
        {
            return _callDetailRecordRepository.GetAll().Where(x => x.CallDate >= startDate && x.CallDate < endDate).ToList();
        }

        public IEnumerable<CallDetailRecord> GetCallRecordsByCallerId(string callerId)
        {
            return _callDetailRecordRepository.GetAll().Where(x => x.CallerId == callerId).ToList();
        }

        public void DeleteCallRecord(Guid id)
        {
            _callDetailRecordRepository.DeleteAsync(id);
        }
        public CallerTotals GetCallerTotals(string caller_id)
        {
            var totalcost = _callDetailRecordRepository.GetTotalCallCost();
            var averageduration = _callDetailRecordRepository.GetAverageDuration();
            var averagecost = _callDetailRecordRepository.GetAverageCost();

            return new CallerTotals
            {
                CallerId = caller_id,
                AverageCost = averagecost,
                AverageDuration = averageduration,
                TotalCost = totalcost,
            };
        }
    }
}
