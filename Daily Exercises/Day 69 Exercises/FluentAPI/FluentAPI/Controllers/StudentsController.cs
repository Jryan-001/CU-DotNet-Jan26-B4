using Microsoft.AspNetCore.Mvc;
using FluentAPI.Model;
using FluentAPI.DTOs;
using FluentAPI.Repositories;

namespace FluentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _studentRepository.GetAllAsync();
            var studentDtos = students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                CourseIds = s.Courses.Select(c => c.Id).ToList()
            });

            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDto = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                CourseIds = student.Courses.Select(c => c.Id).ToList()
            };

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> PostStudent(StudentDto studentDto)
        {
            if (await _studentRepository.EmailExistsAsync(studentDto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var student = new Student
            {
                Name = studentDto.Name,
                Email = studentDto.Email,
                Age = studentDto.Age
            };

            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();

            studentDto.Id = student.Id;
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, studentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentDto studentDto)
        {
            if (id != studentDto.Id)
            {
                return BadRequest();
            }

            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            if (await _studentRepository.EmailExistsAsync(studentDto.Email, id))
            {
                return BadRequest("Email already exists.");
            }

            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            student.Age = studentDto.Age;

            await _studentRepository.UpdateAsync(student);
            await _studentRepository.SaveChangesAsync();

            return Ok(studentDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (!await _studentRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _studentRepository.DeleteAsync(id);
            await _studentRepository.SaveChangesAsync();

            return Ok(new { message = "Student deleted successfully" });
        }
    }
}
