using PruebaPractica.Shared;
using System.Net.Http.Json;

namespace BlazorPruebaPractica.Client.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _httpClient;    

        public PersonService(HttpClient http)
        {
            _httpClient = http; 
        }

        public async Task<PersonDto> Buscar(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseApi<PersonDto>>($"api/Person/Buscar/{id}");
            if (result!.Success)
                return result.Value;
            else
                throw new NotImplementedException();
        }

        public async Task<int> Editar(PersonDto person)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Person/Editar/{person.Id}", person);
            var response = await result.Content.ReadFromJsonAsync<ResponseApi<int>>();
            if (response!.Success)
                return response.Value;
            else
                throw new NotImplementedException();
        }

        public async Task<int> Guardar(PersonDto person)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Person/Guardar",person);
            var response = await result.Content.ReadFromJsonAsync<ResponseApi<int>>();
            if (response!.Success)
                return response.Value;
            else
                throw new NotImplementedException();
        }

        public async Task<List<PersonDto>> Lista()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseApi<List<PersonDto>>>("api/Person/Lista");
            if (result!.Success)
                return result.Value;
            else
                throw new NotImplementedException();
        }
    }
}
