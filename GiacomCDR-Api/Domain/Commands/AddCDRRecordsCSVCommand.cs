using GiacomCDR_Api.Domain.Responses;
using MediatR;

namespace GiacomCDR_Api.Domain.Commands
{
    public class AddCDRRecordsCSVCommand : IRequest<CommandResponse_Bool>
    {
        public string File { get; set; }
    }
}
