using FrontendMVC.Models;

namespace FrontendMVC.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<DestinationViewModel>> GetAllAsync();
        Task<DestinationViewModel> GetByIdAsync(int id);
        Task CreateAsync(DestinationViewModel destination);
        Task UpdateAsync(DestinationViewModel destination);
        Task DeleteAsync(int id);
    }
}
