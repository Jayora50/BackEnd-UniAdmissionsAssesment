using MediatR;
using System.Collections.Generic;
using UniAdmissionsAssesment.Entities.TransferDTOs;

namespace UniAdmissionsAssesment.Queries
{
    public class GetAllBooks : IRequest<Response<IEnumerable<BookTransferDTO>>>
    {
        
    }
}
