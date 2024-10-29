using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class BuysRepository : IBuysRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="BuysRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public BuysRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Buys por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Buys</returns>
        public async Task<Buys> FindAsync(int id)
        {
            return await _context.Buys.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Buyss
        /// </summary>
        /// <returns>Retorna toda la data de las Buyss</returns>
        public Task<List<Buys>> AllAsync()
        {
            return _context.Buys.ToListAsync();
        }

        /// <summary>
        /// Crea una Buys
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Buys creada</returns>
        public async Task<bool> CreateAsync(Buys data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Buys.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una Buys
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Buys data)
        {
            try
            {
                var entity = await _context.Buys.FindAsync(id);
                if (entity != null)
                {
                    entity.Supplier_Id = id;
                    entity.Date = data.Date;
                    entity.Total = data.Total;
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
        public ICollection<Buys> GetBuys()
        {
            return _context.Buys.ToList();
        }

        public ICollection<Suppliers> GetBuysBySuppliers(int buysId)
        {
            return _context.Suppliers.Where(e => e.Id == buysId).ToList();
        }
    }
}
