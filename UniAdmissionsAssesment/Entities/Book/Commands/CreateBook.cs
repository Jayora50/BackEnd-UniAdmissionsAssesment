using MediatR;
using UniAdmissionsAssesment.Entities.TransferDTOs;
using UniAdmissionsAssesment.Entities.ViewModels;

namespace UniAdmissionsAssesment
{
    public class CreateBook : IRequest<Response<BookTransferDTO>>
    {
        public CreateBookModel Book { get; set; }
    }
}