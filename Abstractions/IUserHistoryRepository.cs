using System.Collections;
using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IUserHistoryRepository
    {
       ICollection<UsersHistory> GetUserHistories();

        Task<UsersHistory> FindAsync(int id);
        /// <summary>
        /// Consulta una UsersHistory por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha UsersHistory</returns>
        Task<List<UsersHistory>> AllAsync();
        /// <summary>
        /// Consulta todas las UsersHistorys
        /// </summary>
        /// <returns>Retorna una lista de UsersHistorys</returns>
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
        bool UserHistoryExits(int UserHistoryid);
        object GetUserHistory(int userHistoryid);
    }
}
