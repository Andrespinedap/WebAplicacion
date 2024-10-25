using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class InventoryRepository : IxInventoryRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="InventoryRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public InventoryRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Inventory por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Inventory</returns>
        public async Task<Inventory> FindAsync(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Inventorys
        /// </summary>
        /// <returns>Retorna toda la data de las Inventorys</returns>
        public Task<List<Inventory>> AllAsync()
        {
            return _context.Inventories.ToListAsync();
        }

        /// <summary>
        /// Crea una Inventory
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Inventory creada</returns>
        public async Task<bool> CreateAsync(Inventory data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Inventories.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una Inventory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Inventory data)
        {
            try
            {
                var entity = await _context.Inventories.FindAsync(id);
                if (entity != null)
                {
                    entity.Name = data.Name;
                    entity.Description = data.Description;
                    entity.Amount = data.Amount;
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
        public ICollection<Inventory> GetInventory()
        {
            throw new NotImplementedException();
        }
    }
}
