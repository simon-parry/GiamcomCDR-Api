using GiacomCDR_Api.Domain.Responses;
using GiacomCDR_Api.Models;
using MediatR;

namespace GiacomCDR_Api.Domain.Commands
{
    public class GetCallerTotalsCommand : IRequest<CommandResponseSingle<CallerTotals>>
    {
        public string CallerId { get; set; } = string.Empty;
    }
}
