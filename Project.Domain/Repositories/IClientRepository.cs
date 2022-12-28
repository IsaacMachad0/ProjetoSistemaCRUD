using Project.Domain.Entities;

namespace Project.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Client> CreateClientAsync(Client client);
        Task<ICollection<Client>> GetClientsAsync();
        Task<Client> GetByIdClientAsync(int id);
        Task DeleteClientAsync(Client client);
        Task EditClientAsync(Client client);
    }
}
