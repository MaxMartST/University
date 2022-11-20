using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using University.Data;

namespace University.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly UniversityContext _context;
        public UnitOfWork(UniversityContext context) => _context = context;
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
