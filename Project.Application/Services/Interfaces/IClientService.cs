using Project.Application.DTOs;
using Project.Application.Services.Validations;

namespace Project.Application.Services.Interfaces
{
    public interface IClientService
    {
        Task<ResultService<ClientDTO>> CreateClientAsync(ClientDTO clientDTO);
        Task<ResultService<ClientDTO>> GetByIdClientAsync(int id);
        Task<ResultService<ICollection<ClientDTO>>> GetClientsAsync();
        Task<ResultService> EditClientAsync(ClientDTO clientDTO);
        Task<ResultService> DeleteClientAsync(int id);
    }
}
