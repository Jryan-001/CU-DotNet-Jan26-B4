using Microsoft.AspNetCore.Mvc;
using FluentAPI.DTOs;
using FluentAPI.Repositories;

namespace FluentAPI.Controllers
{
    [Route("api/enroll")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentController(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollmentDto enrollmentDto)
        {
            var student = await _studentRepository.GetByIdAsync(enrollmentDto.StudentId);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var course = await _courseRepository.GetByIdAsync(enrollmentDto.CourseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            if (student.Courses.Any(c => c.Id == enrollmentDto.CourseId))
            {
                return BadRequest("Student is already enrolled in this course.");
            }

            await _studentRepository.EnrollInCourseAsync(enrollmentDto.StudentId, enrollmentDto.CourseId);
            await _studentRepository.SaveChangesAsync();

            return Ok(new { message = "Student successfully enrolled in course." });
        }
    }
}
