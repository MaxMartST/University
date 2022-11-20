using System.Collections.Generic;
using University.Models;

namespace University.Dto.Response
{
    public class CourseResponseDto
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public ICollection<EnrollmentDto> Enrollments { get; set; }
    }
}
