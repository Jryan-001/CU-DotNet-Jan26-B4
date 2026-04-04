using FrontendMVC.Models;
using FrontendMVC.Services;
namespace FrontendMVC.Services
{
    public class DestinationService: IDestinationService
    {
        private readonly HttpClient _httpClient;
        public DestinationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DestinationViewModel>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<DestinationViewModel>>("api/Destinations");
        }

        public async Task<DestinationViewModel> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<DestinationViewModel>($"api/Destinations/{id}");
        }

        public async Task CreateAsync(DestinationViewModel destination)
        {
            await _httpClient.PostAsJsonAsync("api/Destinations", destination);
        }

        public async Task UpdateAsync(DestinationViewModel destination)
        {
            await _httpClient.PutAsJsonAsync($"api/Destinations/{destination.Id}", destination);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Destinations/{id}");
        }
    }

}
