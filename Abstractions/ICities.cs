using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface ICities
    {
        ICollection<Cities> GetCities();
        //Llamar el Modelo de datos

        Task<Cities> FindAsync(int id);
        /// <summary>
        /// Consulta una Cities por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Cities</returns>
        Task<List<Cities>> AllAsync();
        /// <summary>
        /// Consulta todas las Citiess
        /// </summary>
        /// <returns>Retorna una lista de Citiess</returns>
        Task<bool> CreateAsync(Cities data);
        /// <summary>
        /// Crea una Cities
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Cities</returns>
        Task<bool> UpdateAsync(int id, Cities data);
        /// <summary>
        /// Actualiza una Cities mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
