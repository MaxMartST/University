using AutoMapper;
using University.Dto;
using University.Dto.Request;
using University.Dto.Response;
using University.Models;

namespace University.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<CourseDto, Course>();
            CreateMap<Course, CourseDto>();
            CreateMap<Course, CourseResponseDto>();
            CreateMap<CourseRequestDto, Course>();

            CreateMap<Enrollment, EnrollmentDto>();
            CreateMap<Enrollment, EnrollmentStudentResponseDto>();
        }
    }
}
