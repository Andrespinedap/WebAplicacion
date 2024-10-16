using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IOrdersRepository
    {
        ICollection<Order> GetOrders();
        Task<Order> FindAsync(int id);
        /// <summary>
        /// Consulta un Order por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Order</returns>
        Task<List<Order>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Order data);
        /// <summary>
        /// Crea una Order
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Order</returns>
        Task<bool> UpdateAsync(int id, Order data);
        /// <summary>
        /// Actualiza una Order mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
