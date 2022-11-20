using University.Data;

namespace University.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly UniversityContext _context;

        public BaseRepository(UniversityContext context) => _context = context;
    }
}
