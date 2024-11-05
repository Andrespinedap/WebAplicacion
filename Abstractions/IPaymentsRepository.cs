using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IPaymentsRepository
    {
        ICollection<Payments> GetPayments();
        Task<Payments> FindAsync(int id);

        /// <summary>
        /// Consulta un Payments por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Payments</returns>
        Task<List<Payments>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Payments data);
        /// <summary>
        /// Crea una Payments
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Payments</returns>
        Task<bool> UpdateAsync(int id, Payments data);
        /// <summary>
        /// Actualiza una Payments mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
