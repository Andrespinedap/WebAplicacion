using WebAplicacion.Model;

namespace WebAplicacion.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        //Llamar el Modelo de datos

        Task<User> FindAsync(int id);
        /// <summary>
        /// Consulta una User por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha User</returns>
        Task<List<User>> AllAsync();
        /// <summary>
        /// Consulta todas las Users
        /// </summary>
        /// <returns>Retorna una lista de Users</returns>
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
