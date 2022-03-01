using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniAdmissionsAssesment.Entities;
using UniAdmissionsAssesment.Repository;

namespace UniAdmissionsAssesment
{
    public class DeleteBookHandler : IRequestHandler<DeleteBook, Response<Book>>
    {
        private readonly IBookRepository _bookRepo;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBookHandler(IBookRepository bookRepo, IUnitOfWork unitOfWork)
        {
            _bookRepo = bookRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<Book>> Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _bookRepo.FindByIdAsync(request.BookId);
                if (book == null)
                {
                    return new Response<Book>(404, "Book Not Found.");
                }
                _bookRepo.Delete(book);
                await _unitOfWork.CompleteAsync();

                return new Response<Book>(book);
            }
            catch (Exception ex)
            {
                return new Response<Book>(500, $"An error occured {ex.Message}.");
            }    
        }
    }
}