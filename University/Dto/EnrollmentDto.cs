using University.Models;

namespace University.Dto
{
    public class EnrollmentDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
    }
}
