using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniAdmissionsAssesment.Entities;

namespace UniAdmissionsAssesment.Repository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(SampleAppContext context) : base(context)
        {
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<Book> FindByIdAsync(long id)
        {
            return await _context.Books.FindAsync(id);            
        }

        public async Task<IEnumerable<Book>> ListAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
