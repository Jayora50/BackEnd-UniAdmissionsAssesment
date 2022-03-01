using System.Collections.Generic;
using System.Threading.Tasks;
using UniAdmissionsAssesment.Entities;

namespace UniAdmissionsAssesment.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListAsync();
        Task<Book> FindByIdAsync(long Id);
        Task AddAsync(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}
