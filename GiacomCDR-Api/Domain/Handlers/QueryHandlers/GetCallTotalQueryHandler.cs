using GiacomCDR_Api.Domain.Commands;
using GiacomCDR_Api.Domain.Responses;
using GiacomCDR_Api.Models;
using GiacomCDR_Api.Services;
using MediatR;

namespace GiacomCDR_Api.Domain.Handlers.QueryHandlers
{
    public class GetCallTotalQueryHandler : IRequestHandler<GetCallerTotalsCommand, CommandResponseSingle<CallerTotals>>
    {
        ICallDetailRecordService _callDetailRecordService;
        public GetCallTotalQueryHandler(ICallDetailRecordService callDetailRecordService)
        {
            _callDetailRecordService = callDetailRecordService;
        }
        public async Task<CommandResponseSingle<CallerTotals>> Handle(GetCallerTotalsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _callDetailRecordService.GetCallerTotals(request.CallerId);

                return new CommandResponseSingle<CallerTotals>
                {
                    Result = result
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
