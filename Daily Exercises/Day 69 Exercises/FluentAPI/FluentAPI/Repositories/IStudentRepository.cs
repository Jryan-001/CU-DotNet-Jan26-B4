using FluentAPI.Model;

namespace FluentAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> EmailExistsAsync(string email, int? excludeId = null);
        Task EnrollInCourseAsync(int studentId, int courseId);
        Task SaveChangesAsync();
    }
}
