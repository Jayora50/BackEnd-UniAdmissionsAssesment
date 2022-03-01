using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniAdmissionsAssesment.Entities.TransferDTOs;
using UniAdmissionsAssesment.Repository;

namespace UniAdmissionsAssesment
{
    public class UpdateBookHandler : IRequestHandler<UpdateBook, Response<BookTransferDTO>>
    {
        private readonly IBookRepository _bookRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateBookHandler(IBookRepository bookRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<BookTransferDTO>> Handle(UpdateBook request, CancellationToken cancellationToken)
        {
            if (request.Id != request.Book.Id)
            {
                return new Response<BookTransferDTO>(400, "Bad Request.");
            }

            try
            {
                var book = await _bookRepo.FindByIdAsync(request.Id);

                if (book == null)
                {
                    return new Response<BookTransferDTO>(404, "Book Not Found.");
                }

                book.Author = request.Book.Author;
                book.Title = request.Book.Title;
                book.ModifiedDate = DateTimeOffset.Now;

                _bookRepo.Update(book);
                await _unitOfWork.CompleteAsync();

                var result = _mapper.Map<BookTransferDTO>(book);
                return new Response<BookTransferDTO>(result);
            }
            catch (Exception ex)
            {
                return new Response<BookTransferDTO>(500, $"An exception occurred. {ex.Message}");
            }
        }
    }
}