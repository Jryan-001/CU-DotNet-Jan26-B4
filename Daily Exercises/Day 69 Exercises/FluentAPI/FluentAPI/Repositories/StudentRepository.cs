using Microsoft.EntityFrameworkCore;
using FluentAPI.Data;
using FluentAPI.Model;

namespace FluentAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly FluentAPIContext _context;

        public StudentRepository(FluentAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.Include(s => s.Courses).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Students.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Students.AnyAsync(e => e.Email == email && e.Id != excludeId);
            }
            return await _context.Students.AnyAsync(e => e.Email == email);
        }

        public async Task EnrollInCourseAsync(int studentId, int courseId)
        {
            var student = await _context.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == studentId);
            
            var course = await _context.Courses.FindAsync(courseId);

            if (student != null && course != null && !student.Courses.Any(c => c.Id == courseId))
            {
                student.Courses.Add(course);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
