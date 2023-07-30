using GiacomCDR_Api.Domain.Commands;
using GiacomCDR_Api.Domain.Responses;
using GiacomCDR_Api.Services;
using MediatR;

namespace GiacomCDR_Api.Domain.Handlers.CommandHandlers
{
    public class AddCDRRecordsCSVCommandHandler : IRequestHandler<AddCDRRecordsCSVCommand, CommandResponse_Bool>
    {
        ICallDetailRecordService _callDetailRecordService;

        public AddCDRRecordsCSVCommandHandler(ICallDetailRecordService callDetailRecordService)
        {
            _callDetailRecordService = callDetailRecordService;
        }
        public async Task<CommandResponse_Bool> Handle(AddCDRRecordsCSVCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _callDetailRecordService.ImportData(request.File);

                return new CommandResponse_Bool
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

