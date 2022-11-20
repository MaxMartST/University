using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Dto;
using University.Dto.Request;
using University.Dto.Response;
using University.Models;
using University.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;   
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper) 
        { 
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cours = await _courseRepository.ListAsync();

            return Ok(_mapper.Map<ICollection<CourseDto>>(cours));
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
                return NotFound();

            return Ok(_mapper.Map<CourseResponseDto>(course));
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseRequestDto courseRequestDto)
        {
            var course = _mapper.Map<Course>(courseRequestDto);
            _courseRepository.Add(course);
            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<CourseDto>(course));
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseRequestDto courseRequestDto)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
                return NotFound();

            course.Title = courseRequestDto.Title;
            course.Credits = courseRequestDto.Credits;

            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<CourseDto>(course));
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
                return NotFound();

            _courseRepository.Delete(course);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}
