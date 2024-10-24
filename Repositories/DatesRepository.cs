using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class DatesRepository : IDatesRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="DatesRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public DatesRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Dates por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Dates</returns>
        public async Task<Dates> FindAsync(int id)
        {
            return await _context.Dates.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Datess
        /// </summary>
        /// <returns>Retorna toda la data de las Datess</returns>
        public Task<List<Dates>> AllAsync()
        {
            return _context.Dates.ToListAsync();
        }

        /// <summary>
        /// Crea una Dates
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Dates creada</returns>
        public async Task<bool> CreateAsync(Dates data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Dates.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una Dates
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Dates data)
        {
            try
            {
                var entity = await _context.Dates.FindAsync(id);
                if (entity != null)
                {
                    entity.Client_Id = id;
                    entity.Vehicle_Id = id;
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
        public ICollection<Dates> GetDates()
        {
            throw new NotImplementedException();
        }
    }
}
