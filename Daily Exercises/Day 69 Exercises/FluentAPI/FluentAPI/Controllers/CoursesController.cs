using Microsoft.AspNetCore.Mvc;
using FluentAPI.Model;
using FluentAPI.DTOs;
using FluentAPI.Repositories;

namespace FluentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _courseRepository.GetAllAsync();
            var courseDtos = courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Credits = c.Credits,
                StudentIds = c.Students.Select(s => s.Id).ToList()
            });

            return Ok(courseDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            var courseDto = new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits,
                StudentIds = course.Students.Select(s => s.Id).ToList()
            };

            return Ok(courseDto);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> PostCourse(CourseDto courseDto)
        {
            var course = new Course
            {
                Title = courseDto.Title,
                Credits = courseDto.Credits
            };

            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();

            courseDto.Id = course.Id;
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, courseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseDto courseDto)
        {
            if (id != courseDto.Id)
            {
                return BadRequest();
            }

            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            course.Title = courseDto.Title;
            course.Credits = courseDto.Credits;

            await _courseRepository.UpdateAsync(course);
            await _courseRepository.SaveChangesAsync();

            return Ok(courseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (!await _courseRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _courseRepository.DeleteAsync(id);
            await _courseRepository.SaveChangesAsync();

            return Ok(new { message = "Course deleted successfully" });
        }
    }
}
