using WebAplicacion.Model;

namespace WebAplicacion.Abstracion
{
    public interface IClienRepository
    {

        /// <summary>
        /// Consulta una Client por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Client</returns>
        Task<Client> FindAsync(int id);
        /// <summary>
        /// Consulta todas las Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<List<Client>> AllAsync();
        /// <summary>
        /// Crea una Client
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Client</returns>
        Task<bool> CreateAsync(Client data);
        /// <summary>
        /// Actualiza una Client mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
        Task<bool> UpdateAsync(int id, Client data);
    }
}
    

