using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IxInventory_purchaseRepository
    {
        ICollection<Inventory_purchase> GetInventory_Purchases();
        Task<Inventory_purchase> FindAsync(int id);
        /// <summary>
        /// Consulta un Inventory_purchase por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Inventory_purchase</returns>
        Task<List<Inventory_purchase>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Inventory_purchase data);
        /// <summary>
        /// Crea una Inventory_purchase
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Inventory_purchase</returns>
        Task<bool> UpdateAsync(int id, Inventory_purchase data);
        /// <summary>
        /// Actualiza una Inventory_purchase mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
