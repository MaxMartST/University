using University.Models;

namespace University.Dto.Response
{
    public class EnrollmentStudentResponseDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

        public StudentDto Student { get; set; }
    }
}
