using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IServices_OrdersRepository
    {
        ICollection<Services_Orders> GetServices_Orders();
        Task<Services_Orders> FindAsync(int id);
        /// <summary>
        /// Consulta un Services_Orders por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Services_Orders</returns>
        Task<List<Services_Orders>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Services_Orders data);
        /// <summary>
        /// Crea una Services_Orders
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Services_Orders</returns>
        Task<bool> UpdateAsync(int id, Services_Orders data);
        /// <summary>
        /// Actualiza una Services_Orders mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
