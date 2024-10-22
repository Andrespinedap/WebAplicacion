using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IComentariosClientes
    {
        ICollection<ComentariosClientes> GetComentariosClientes();
        //Llamar el Modelo de datos

        Task<ComentariosClientes> FindAsync(int id);
        /// <summary>
        /// Consulta una ComentariosClientes por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha ComentariosClientes</returns>
        Task<List<ComentariosClientes>> AllAsync();
        /// <summary>
        /// Consulta todas las ComentariosClientess
        /// </summary>
        /// <returns>Retorna una lista de ComentariosClientess</returns>
        Task<bool> CreateAsync(ComentariosClientes data);
        /// <summary>
        /// Crea una ComentariosClientes
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la ComentariosClientes</returns>
        Task<bool> UpdateAsync(int id, ComentariosClientes data);
        /// <summary>
        /// Actualiza una ComentariosClientes mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
