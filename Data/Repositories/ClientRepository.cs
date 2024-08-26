using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ClientRepository
    {
        private readonly AFIPContext _context;

        public ClientRepository(AFIPContext context)
        {
            _context = context;
        }
        public async Task AddClientAsync(Client client)
        {
            var existingClient = await _context.Clients
                .Where(c => c.CUIT == client.CUIT && c.PhoneNumber == client.PhoneNumber)
                .FirstOrDefaultAsync();

            if (existingClient != null)
            {
                //TODO: revisar aca si avisar o hacer algo al ya tener agregado ese cliente.
                //throw new InvalidOperationException("A client with the same CUIT and PhoneNumber already exists.");
            }

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.OrderBy(c => c.Name).ToListAsync();
        }

        
    }
}
