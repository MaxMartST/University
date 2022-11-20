using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Models;

namespace University.Repositories
{
    public interface ICourseRepository
    {
        Task<ICollection<Course>> ListAsync();
        void Add(Course course);
        void Delete(Course course);
        Task<Course> GetByIdAsync(int id);
    }
}
