using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="EmployeeRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public EmployeeRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Employee por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Employee</returns>
        public async Task<Employee> FindAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Employees
        /// </summary>
        /// <returns>Retorna toda la data de las Employees</returns>
        public Task<List<Employee>> AllAsync()
        {
            return _context.Employees.ToListAsync();
        }

        /// <summary>
        /// Crea una Employee
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Employee creada</returns>
        public async Task<bool> CreateAsync(Employee data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Employees.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una Employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Employee data)
        {
            try
            {
                var entity = await _context.Employees.FindAsync(id);
                if (entity != null)
                {
                    entity.Name = data.Name;
                    entity.Email = data.Email;
                    entity.Phone = data.Phone;
                    entity.Position = data.Position;
                    _context.Update(entity);

                    return (await _context.SaveChangesAsync()) > 0;
                }
                return false;

            }
            catch (Exception err)
            {

                throw new InvalidOperationException("Ha ocurrido un error: " + err);
            }
        }
        public ICollection<Employee> GetEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
