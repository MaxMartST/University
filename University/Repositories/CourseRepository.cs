using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Data;
using University.Models;

namespace University.Repositories
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public CourseRepository(UniversityContext context) : base(context)
        {
        }

        public void Add(Course course)
        {
            _context.Courses.AddAsync(course);
        }

        public void Delete(Course course)
        {
            _context.Courses.Remove(course);
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.Include(c => c.Enrollments).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<Course>> ListAsync()
        {
            return await _context.Courses.ToListAsync();    
        }
    }
}
