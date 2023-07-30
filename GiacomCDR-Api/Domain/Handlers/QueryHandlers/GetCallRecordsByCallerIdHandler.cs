using GiacomCDR_Api.Domain.Commands;
using GiacomCDR_Api.Domain.Responses;
using GiacomCDR_Api.Models;
using GiacomCDR_Api.Services;
using MediatR;

namespace GiacomCDR_Api.Domain.Handlers.QueryHandlers
{
    public class GetCallRecordsByCallerIdHandler : IRequestHandler<GetCallRecordsByIdCommand, CommandResponse<CallDetailRecord>>
    {
        ICallDetailRecordService _callDetailRecordService;
        public GetCallRecordsByCallerIdHandler(ICallDetailRecordService callDetailRecordService)
        {
            _callDetailRecordService = callDetailRecordService;
        }
        public async Task<CommandResponse<CallDetailRecord>> Handle(GetCallRecordsByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _callDetailRecordService.GetCallRecordsByCallerId(request.CallerId);

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
