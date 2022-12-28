using Project.Application.DTOs;
using Project.Application.Services.Validations;

namespace Project.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<UserDTO>> CreateUserAsync(UserDTO userDTO);
        Task<ResultService<UserDTO>> GetByIdUserAsync(int id);
        Task<ResultService<ICollection<UserDTO>>> GetUsersAsync();
        Task<ResultService> EditUserAsync(UserDTO userDTO);
        Task<ResultService> DeleteUserAsync(int id);
    }
}
