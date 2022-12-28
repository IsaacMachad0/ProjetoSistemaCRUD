using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Repositories;
using Project.Infra.Data.Context;

namespace Project.Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ProjectContext _context;

        public ClientRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClientAsync(Client client)
        {
            _context.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task EditClientAsync(Client client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetByIdClientAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Client>> GetClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
