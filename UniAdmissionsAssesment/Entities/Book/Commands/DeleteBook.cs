using MediatR;
using UniAdmissionsAssesment.Entities;

namespace UniAdmissionsAssesment
{
    public class DeleteBook : IRequest<Response<Book>>
    {
        public long BookId { get; set; }
    }
}