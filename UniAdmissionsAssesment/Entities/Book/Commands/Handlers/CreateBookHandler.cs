using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniAdmissionsAssesment.Entities;
using UniAdmissionsAssesment.Entities.TransferDTOs;
using UniAdmissionsAssesment.Repository;

namespace UniAdmissionsAssesment
{
    public class CreateBookHandler : IRequestHandler<CreateBook, Response<BookTransferDTO>>
    {
        private readonly IBookRepository _bookRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateBookHandler(IUnitOfWork unitOfWork, IBookRepository bookRepo, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookRepo = bookRepo;
            _mapper = mapper;
        }
        public async Task<Response<BookTransferDTO>> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            try
            {
                var book = _mapper.Map<Book>(request.Book);

                book.CreatedDate = DateTimeOffset.Now;

                await _bookRepo.AddAsync(book);
                await _unitOfWork.CompleteAsync();

                var result = _mapper.Map<BookTransferDTO>(book);

                return new Response<BookTransferDTO>(result);
            }
            catch (Exception ex)
            {
                return new Response<BookTransferDTO>(500, $"An error occured. {ex.Message}");
            }
        }
    }
}