using GiacomCDR_Api.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GiacomCDR_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallDetailRecordController : ApiBaseController
    {
        public CallDetailRecordController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetCallRecords")]
        public async Task<IActionResult> GetCallRecords(string startDate = "", string endDate = "")
        {
            return Single(await QueryAsync(new GetCallRecordsCommand { StartDate = DateTime.Parse(startDate), EndDate = DateTime.Parse(endDate) }));           
        }

        [HttpGet("GetCallRecordsByCallerId")]
        public async Task<IActionResult> GetCallRecordsByCallerId(string callerId)
        {
            return Single(await QueryAsync(new GetCallRecordsByIdCommand { CallerId = callerId }));
        }

        [HttpGet("GetCallerTotals")]
        public async Task<IActionResult> GetCallerTotals(string callerId)
        {
            return Single(await QueryAsync(new GetCallerTotalsCommand { CallerId = callerId }));
        }

        [HttpDelete("DeleteCallRecord")]
        public async Task<IActionResult> DeleteCallRecord(Guid callRecordId)
        {
            return Single(await CommandAsync(new DeleteCallRecordCommand { Id = callRecordId }));
        }        
    }
}
