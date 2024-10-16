using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IMaintenance_HistoryRepository
    {
        ICollection<Maintenance_History> GetMaintenance_History();
        Task<Maintenance_History> FindAsync(int id);
        /// <summary>
        /// Consulta un Maintenance_History por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Maintenance_History</returns>
        Task<List<Maintenance_History>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Maintenance_History data);
        /// <summary>
        /// Crea una Maintenance_History
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Maintenance_History</returns>
        Task<bool> UpdateAsync(int id, Maintenance_History data);
        /// <summary>
        /// Actualiza una Maintenance_History mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
