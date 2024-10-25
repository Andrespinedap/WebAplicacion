using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class MaintenanceHistoryRepository : IMaintenance_HistoryRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="MaintenanceHistoryRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public MaintenanceHistoryRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una MaintenanceHistory por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una MaintenanceHistory</returns>
        public async Task<Maintenance_History> FindAsync(int id)
        {
            return await _context.Maintenance_History.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las MaintenanceHistory
        /// </summary>
        /// <returns>Retorna toda la data de las MaintenanceHistory</returns>
        public Task<List<Maintenance_History>> AllAsync()
        {
            return _context.Maintenance_History.ToListAsync();
        }

        /// <summary>
        /// Crea una MaintenanceHistory
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la MaintenanceHistory creada</returns>
        public async Task<bool> CreateAsync(Maintenance_History data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Maintenance_History.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una MaintenanceHistory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Maintenance_History data)
        {
            try
            {
                var entity = await _context.Maintenance_History.FindAsync(id);
                if (entity != null)
                {
                    entity.Date = DateTime.Now;
                    entity.Vehicle_Id = id;
                    entity.Details = data.Details;
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
        public ICollection<Maintenance_History> GetMaintenance_History()
        {
            throw new NotImplementedException();
        }
    }
}
