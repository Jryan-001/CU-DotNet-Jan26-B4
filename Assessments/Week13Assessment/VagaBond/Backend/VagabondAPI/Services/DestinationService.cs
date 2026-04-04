using VagabondAPI.Repository;

namespace VagabondAPI.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repository;
        public DestinationService(IDestinationRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Models.Destination>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Models.Destination> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Models.Destination destination)
        {
            await _repository.AddAsync(destination);
        }

        public async Task UpdateAsync(Models.Destination destination)
        {
            await _repository.UpdateAsync(destination);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
