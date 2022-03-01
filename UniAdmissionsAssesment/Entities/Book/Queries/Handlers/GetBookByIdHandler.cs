using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniAdmissionsAssesment.Entities.TransferDTOs;
using UniAdmissionsAssesment.Queries;
using UniAdmissionsAssesment.Repository;

namespace UniAdmissionsAssesment.QueryHandlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookById, Response<BookTransferDTO>>
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        public GetBookByIdHandler(IBookRepository bookrepo, IMapper mapper)
        {
            _bookRepo = bookrepo;
            _mapper = mapper;
        }

        public async Task<Response<BookTransferDTO>> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            var book = await _bookRepo.FindByIdAsync(request.Id);

            if (book == null)
            {
                return new Response<BookTransferDTO>(404, "Book not found.");
            }

            var result = _mapper.Map<BookTransferDTO>(book);

            return new Response<BookTransferDTO>(result);
        }
    }
}
