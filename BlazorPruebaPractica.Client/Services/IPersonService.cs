using PruebaPractica.Shared;

namespace BlazorPruebaPractica.Client.Services
{
    public interface IPersonService
    {
        Task<List<PersonDto>> Lista();
        Task<PersonDto> Buscar(int id);
        Task<int> Guardar(PersonDto person);
        Task<int> Editar(PersonDto person);

    }
}
