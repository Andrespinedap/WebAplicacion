using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="CitiessRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public CitiesRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Citiess por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Citiess</returns>
        public async Task<Cities> FindAsync(int id)
        {
            return await _context.Cities.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Citiesss
        /// </summary>
        /// <returns>Retorna toda la data de las Citiesss</returns>
        public Task<List<Cities>> AllAsync()
        {
            return _context.Cities.ToListAsync();
        }

        /// <summary>
        /// Crea una Citiess
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Citiess creada</returns>
        public async Task<bool> CreateAsync(Cities data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Cities.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una Citiess
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Cities data)
        {
            try
            {
                var entity = await _context.Cities.FindAsync(id);
                if (entity != null)
                {
                    entity.Vehicle_Id = id;
                    entity.Client_Id = id;
                    entity.Date = DateTime.Now;
                    entity.Motive = data.Motive;
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
        public ICollection<Cities> GetCities()
        {
            throw new NotImplementedException();
        }
    }
}
