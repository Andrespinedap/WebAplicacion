using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="ServicesRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public ServicesRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Services por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Services</returns>
        public async Task<Service> FindAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Servicess
        /// </summary>
        /// <returns>Retorna toda la data de las Servicess</returns>
        public Task<List<Service>> AllAsync()
        {
            return _context.Services.ToListAsync();
        }

        /// <summary>
        /// Crea una Services
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Services creada</returns>
        public async Task<bool> CreateAsync(Service data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Services.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una Services
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Service data)
        {
            try
            {
                var entity = await _context.Services.FindAsync(id);
                if (entity != null)
                {
                    entity.Name = data.Name;
                    entity.Description = data.Description;
                    entity.Price = data.Price;
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
        public ICollection<Service> GetServices()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Services.FindAsync(id);
            if (entity != null)
            {
                _context.Services.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
