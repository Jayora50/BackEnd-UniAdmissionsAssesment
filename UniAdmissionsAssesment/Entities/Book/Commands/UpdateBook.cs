using MediatR;
using UniAdmissionsAssesment.Entities.TransferDTOs;
using UniAdmissionsAssesment.Entities.ViewModels;

namespace UniAdmissionsAssesment
{
    public class UpdateBook : IRequest<Response<BookTransferDTO>>
    {
        public UpdateBookModel Book { get; set; }
        public long Id { get; set; }
    }
}