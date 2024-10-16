using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IVehicleRepository
    {
        ICollection<Vehicle> GetVehicles();
        Task<Vehicle> FindAsync(int id);
        /// <summary>
        /// Consulta un Vehicle por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Vehicle</returns>
        Task<List<Vehicle>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Vehicle data);
        /// <summary>
        /// Crea una Vehicle
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Vehicle</returns>
        Task<bool> UpdateAsync(int id, Vehicle data);
        /// <summary>
        /// Actualiza una Vehicle mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
