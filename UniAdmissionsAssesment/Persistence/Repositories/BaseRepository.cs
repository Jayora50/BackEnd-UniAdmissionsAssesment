namespace UniAdmissionsAssesment.Repository
{
    public abstract class BaseRepository
    {
        protected readonly SampleAppContext _context;

        public BaseRepository(SampleAppContext context)
        {
            _context = context;
        }
    }
}
