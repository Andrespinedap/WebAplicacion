using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IBuysRepository
    {
        ICollection<Buys> GetBuys();

        Task<Buys> FindAsync(int id);
        /// <summary>
        /// Consulta una Buys por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Buys</returns>
        Task<List<Buys>> AllAsync();
        /// <summary>
        /// Consulta todas las Buyss
        /// </summary>
        /// <returns>Retorna una lista de Buyss</returns>
        Task<bool> CreateAsync(Buys data);
        /// <summary>
        /// Crea una Buys
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Buys</returns>
        Task<bool> UpdateAsync(int id, Buys data);
        /// <summary>
        /// Actualiza una Buys mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
