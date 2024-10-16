using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IUserRepository
    {
        ICollection<User> GetUser();
        Task<User> FindAsync(int id);
        /// <summary>
        /// Consulta un User por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha User</returns>
        Task<List<User>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(User data);
        /// <summary>
        /// Crea una User
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la User</returns>
        Task<bool> UpdateAsync(int id, User data);
        /// <summary>
        /// Actualiza una User mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>

    }
}
