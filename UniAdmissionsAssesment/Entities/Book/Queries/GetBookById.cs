using MediatR;
using UniAdmissionsAssesment.Entities.TransferDTOs;

namespace UniAdmissionsAssesment.Queries
{
    public class GetBookById : IRequest<Response<BookTransferDTO>>
    {
        public long Id { get; set; }
    }
}
