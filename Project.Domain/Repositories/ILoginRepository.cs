using Project.Domain.Entities;

namespace Project.Domain.Repositories
{
    public interface ILoginRepository
    {
        bool LoginUser(string email, string password);
    }
}
