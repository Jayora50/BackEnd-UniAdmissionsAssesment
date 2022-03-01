using System.Threading.Tasks;

namespace UniAdmissionsAssesment
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleAppContext _context;

        public UnitOfWork(SampleAppContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
