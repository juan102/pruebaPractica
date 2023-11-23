using PruebaPractica.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorPruebaPractica.Client.Services
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient;

        public UserService(HttpClient http)
        {
            _httpClient = http;
        }

        public async Task<int> Login(UserDto user)
        {
            var result = await _httpClient.PostAsJsonAsync("api/User/Login", user);
            var response = await result.Content.ReadFromJsonAsync<ResponseApi<int>>();
            if (response!.Success)
                return response.Value;
            else
                throw new NotImplementedException();
        }
    }
}
