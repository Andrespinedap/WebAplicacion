using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface ISuppliersRepository
    {
        ICollection<Suppliers> GetSuppliers();
        Task<Suppliers> FindAsync(int id);
        /// <summary>
        /// Consulta un Suppliers por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Suppliers</returns>
        Task<List<Suppliers>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Suppliers data);
        /// <summary>
        /// Crea una Suppliers
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Suppliers</returns>
        Task<bool> UpdateAsync(int id, Suppliers data);
        /// <summary>
        /// Actualiza una Suppliers mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
        Task DeleteAsync(int id);
    }
}
