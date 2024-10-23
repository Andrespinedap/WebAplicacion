using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployee();
        Task<Employee> FindAsync(int id);
        /// <summary>
        /// Consulta un Employee por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de dicha Employee</returns>
        Task<List<Employee>> AllAsync();
        /// <summary>
        /// Consulta todos los Clients
        /// </summary>
        /// <returns>Retorna una lista de Clients</returns>
        Task<bool> CreateAsync(Employee data);
        /// <summary>
        /// Crea una Employee
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el ID de la Employee</returns>
        Task<bool> UpdateAsync(int id, Employee data);
        /// <summary>
        /// Actualiza una Employee mediante el Id insertado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna un true si la información se actualizo correctamente</returns>
    }
}
