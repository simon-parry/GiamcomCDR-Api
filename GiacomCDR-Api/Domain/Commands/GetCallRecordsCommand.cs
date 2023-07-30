using GiacomCDR_Api.Domain.Responses;
using GiacomCDR_Api.Models;
using MediatR;

namespace GiacomCDR_Api.Domain.Commands
{
    public class GetCallRecordsCommand : IRequest<CommandResponse<CallDetailRecord>>
    {
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;

    }
}
