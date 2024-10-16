using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    /// <summary>
    /// Interaz que implementa la firma de los metodos
    /// </summary>
    public interface IClientRepository
    {
        ICollection<Client> GetUsers();
        //Llamar el Modelo de datos
      
        Task<Client> FindAsync(int id);
        /// <summary>
        /// Consulta un Client por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Client</returns>
        Task<List<Client>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Client data);
        /// <summary>
        /// Crea una Client
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Client</returns>
        Task<bool> UpdateAsync(int id, Client data);
        /// <summary>
        /// Actualiza una Client mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
