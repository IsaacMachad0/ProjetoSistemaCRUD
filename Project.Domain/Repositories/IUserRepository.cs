using Project.Domain.Entities;

namespace Project.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetByIdUserAsync(int id);
        Task<ICollection<User>> GetUsersAsync();
        Task DeleteUserAsync(User user);
        Task EditUserAsync(User user);
    }
}
