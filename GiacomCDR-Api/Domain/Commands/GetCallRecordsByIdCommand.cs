using GiacomCDR_Api.Domain.Responses;
using GiacomCDR_Api.Models;
using MediatR;

namespace GiacomCDR_Api.Domain.Commands
{
    public class GetCallRecordsByIdCommand : IRequest<CommandResponse<CallDetailRecord>>
    {
        public string CallerId { get; set; }

    }
}
