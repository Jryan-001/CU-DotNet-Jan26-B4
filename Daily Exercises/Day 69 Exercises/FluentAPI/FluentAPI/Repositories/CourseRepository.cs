using Microsoft.EntityFrameworkCore;
using FluentAPI.Data;
using FluentAPI.Model;

namespace FluentAPI.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly FluentAPIContext _context;

        public CourseRepository(FluentAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(c => c.Students).ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Courses.AnyAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
