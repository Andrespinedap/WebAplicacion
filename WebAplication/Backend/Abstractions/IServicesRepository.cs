using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IServicesRepository
    {
        ICollection<Service> GetServices();
        Task<Service> FindAsync(int id);
        /// <summary>
        /// Consulta un Services por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Services</returns>
        Task<List<Service>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Service data);
        /// <summary>
        /// Crea una Services
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Services</returns>
        Task<bool> UpdateAsync(int id, Service data);
        /// <summary>
        /// Actualiza una Services mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
        Task DeleteAsync(int id);
    }
}
