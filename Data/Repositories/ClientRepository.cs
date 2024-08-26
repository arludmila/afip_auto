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
        public async Task<string> AddClientAsync(Client client)
        {
            var existingClient = await _context.Clients
                .Where(c => c.CUIT == client.CUIT && c.PhoneNumber == client.PhoneNumber)
                .FirstOrDefaultAsync();

            if (existingClient != null)
            {
               
                return "El cliente ya existe en la base de datos.";
            }

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return "Cliente agregado a la base de datos exitosamente.";
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.OrderBy(c => c.Name).ToListAsync();
        }

        
    }
}
