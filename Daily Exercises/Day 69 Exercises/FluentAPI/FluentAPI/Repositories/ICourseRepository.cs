using FluentAPI.Model;

namespace FluentAPI.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task SaveChangesAsync();
    }
}
