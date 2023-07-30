using GiacomCDR_Api.Domain.Commands;
using GiacomCDR_Api.Domain.Responses;
using GiacomCDR_Api.Models;
using GiacomCDR_Api.Services;
using MediatR;

namespace GiacomCDR_Api.Domain.Handlers.QueryHandlers
{
    public class GetCallRecordsQueryHandler : IRequestHandler<GetCallRecordsCommand, CommandResponse<CallDetailRecord>>
    {
        ICallDetailRecordService _callDetailRecordService;
        public GetCallRecordsQueryHandler(ICallDetailRecordService callDetailRecordService)
        {
            _callDetailRecordService = callDetailRecordService;
        }
        public async Task<CommandResponse<CallDetailRecord>> Handle(GetCallRecordsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _callDetailRecordService.GetCallRecords(request.StartDate, request.EndDate);

                return new CommandResponse<CallDetailRecord>
                {
                    Result = result.ToList(),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
