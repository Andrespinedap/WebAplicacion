using Microsoft.EntityFrameworkCore;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class VehicleRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="VehicleRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public VehicleRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Vehicle por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Vehicle</returns>
        public async Task<Vehicle> FindAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Vehicles
        /// </summary>
        /// <returns>Retorna toda la data de las Vehicles</returns>
        public Task<List<Vehicle>> AllAsync()
        {
            return _context.Vehicles.ToListAsync();
        }

        /// <summary>
        /// Crea una Vehicle
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Vehicle creada</returns>
        public async Task<bool> CreateAsync(Vehicle data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Vehicles.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una Vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Vehicle data)
        {
            try
            {
                var entity = await _context.Vehicles.FindAsync(id);
                if (entity != null)
                {
                    entity.Client_Id = id;
                    entity.Brand = data.Brand;
                    entity.Model = data.Model;
                    entity.Year = data.Year;
                    entity.Plate = data.Plate;
                    entity.Order = data.Order;
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
        public ICollection<Vehicle> GetVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
