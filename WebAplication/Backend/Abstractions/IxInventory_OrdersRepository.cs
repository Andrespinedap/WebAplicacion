using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IxInventory_OrdersRepository
    {
        ICollection<Inventory_Orders> GetInventory_Orders();
        Task<Inventory_Orders> FindAsync(int id);
        /// <summary>
        /// Consulta un InventoryOrders por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha InventoryOrders</returns>
        Task<List<Inventory_Orders>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Inventory_Orders data);
        /// <summary>
        /// Crea una InventoryOrders
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la InventoryOrders</returns>
        Task<bool> UpdateAsync(int id, Inventory_Orders data);
        /// <summary>
        /// Actualiza una InventoryOrders mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
