using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="SuppliersRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public SuppliersRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Suppliers por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Suppliers</returns>
        public async Task<Suppliers> FindAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Supplierss
        /// </summary>
        /// <returns>Retorna toda la data de las Supplierss</returns>
        public Task<List<Suppliers>> AllAsync()
        {
            return _context.Suppliers.ToListAsync();
        }

        /// <summary>
        /// Crea una Suppliers
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Suppliers creada</returns>
        public async Task<bool> CreateAsync(Suppliers data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Suppliers.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una Suppliers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Suppliers data)
        {
            try
            {
                var entity = await _context.Suppliers.FindAsync(id);
                if (entity != null)
                {
                    entity.Name = data.Name;
                    entity.Contacts = data.Contacts;
                    entity.Address = data.Address;
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
        public ICollection<Suppliers> GetSuppliers()
        {
            throw new NotImplementedException();
        }
    }
}
