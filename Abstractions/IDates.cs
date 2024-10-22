using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IDates
    {
        ICollection<Dates> GetDates();
        //Llamar el Modelo de datos

        Task<Dates> FindAsync(int id);
        /// <summary>
        /// Consulta una Dates por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Dates</returns>
        Task<List<Dates>> AllAsync();
        /// <summary>
        /// Consulta todas las Datess
        /// </summary>
        /// <returns>Retorna una lista de Datess</returns>
        Task<bool> CreateAsync(Dates data);
        /// <summary>
        /// Crea una Dates
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Dates</returns>
        Task<bool> UpdateAsync(int id, Dates data);
        /// <summary>
        /// Actualiza una Dates mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
