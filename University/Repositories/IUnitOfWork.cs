using System.Threading.Tasks;

namespace University.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
