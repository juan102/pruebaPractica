using PruebaPractica.Shared;

namespace BlazorPruebaPractica.Client.Services
{
    public interface IUserService
    {
        Task<int> Login(UserDto user);
    }
}
