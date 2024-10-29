using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly TestDbContext _context;

        public ClientRepository(TestDbContext context) 
        {
            _context = context;
        }
        public async Task<Client> CreateClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Client>> GetAllClientAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            var existingClient = await _context.Clients.FindAsync(client.Id);

            if (existingClient == null)
            {
                throw new NotFoundException("User not found");
            }

            // Actualiza las propiedades según sea necesario
            existingClient.Name = client.Name;
            existingClient.Direccion = client.Direccion;
            existingClient.Email = client.Email;
            existingClient.Telefono = client.Telefono;
            existingClient.ComentariosCliente = client.ComentariosCliente;
            existingClient.Cities = client.Cities;

            _context.Entry(existingClient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingClient;
        }
    }
}
