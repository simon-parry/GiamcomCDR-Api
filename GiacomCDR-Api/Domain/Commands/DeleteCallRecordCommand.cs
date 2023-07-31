using GiacomCDR_Api.Domain.Responses;
using MediatR;

namespace GiacomCDR_Api.Domain.Commands
{
    public class DeleteCallRecordCommand : IRequest<CommandResponse_Bool>
    {
        public Guid Id { get; set; }
    }
}
