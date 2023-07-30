using GiacomCDR_Api.Domain.Commands;
using GiacomCDR_Api.Domain.Responses;
using GiacomCDR_Api.Services;
using MediatR;

namespace GiacomCDR_Api.Domain.Handlers.CommandHandlers
{
    public class DeleteCallRecordCommandHandler : IRequestHandler<DeleteCallRecordCommand, CommandResponse_Bool>
    {
        ICallDetailRecordService _callDetailRecordService;

        public DeleteCallRecordCommandHandler(ICallDetailRecordService callDetailRecordService)
        {
            _callDetailRecordService = callDetailRecordService;
        }
        public async Task<CommandResponse_Bool> Handle(DeleteCallRecordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _callDetailRecordService.DeleteCallRecord(request.Id);

                return new CommandResponse_Bool
                {
                    Result = true
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
