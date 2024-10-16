using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IUserHistoryRepository
    {
        ICollection<UsersHistory> GetOrders();
        Task<UsersHistory> FindAsync(int id);
        /// <summary>
        /// Consulta un UsersHistory por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha UsersHistory</returns>
        Task<List<UsersHistory>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(UsersHistory data);
        /// <summary>
        /// Crea una UsersHistory
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la UsersHistory</returns>
        Task<bool> UpdateAsync(int id, UsersHistory data);
        /// <summary>
        /// Actualiza una UsersHistory mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
