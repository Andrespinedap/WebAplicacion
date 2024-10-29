using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    /// <summary>
    /// Interaz que implementa la firma de los metodos
    /// </summary>
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClientAsync();
        Task<Client> GetClientAsync(int id);
        Task<Client> CreateClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task DeleteClientAsync(int id);
    }
}
