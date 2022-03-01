using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniAdmissionsAssesment.Entities.TransferDTOs;
using UniAdmissionsAssesment.Queries;
using UniAdmissionsAssesment.Repository;

namespace UniAdmissionsAssesment.QueryHandlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooks, Response<IEnumerable<BookTransferDTO>>>
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        public GetAllBooksHandler(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<BookTransferDTO>>> Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            var books = await _bookRepo.ListAsync();

            var results =  _mapper.Map<IEnumerable<BookTransferDTO>>(books);
                
            return new Response<IEnumerable<BookTransferDTO>>(results);
        }
    }
}
