using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IxInventoryRepository
    {
        ICollection<Inventory> GetInventory();
        Task<Inventory> FindAsync(int id);
        /// <summary>
        /// Consulta un Inventory por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Inventory</returns>
        Task<List<Inventory>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Inventory data);
        /// <summary>
        /// Crea una Inventory
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Inventory</returns>
        Task<bool> UpdateAsync(int id, Inventory data);
        /// <summary>
        /// Actualiza una Inventory mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
