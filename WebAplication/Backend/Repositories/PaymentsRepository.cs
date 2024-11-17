using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="PaymentsRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public PaymentsRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Payments por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Payments</returns>
        public async Task<Payments> FindAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Paymentss
        /// </summary>
        /// <returns>Retorna toda la data de las Paymentss</returns>
        public Task<List<Payments>> AllAsync()
        {
            return _context.Payments.ToListAsync();
        }

        /// <summary>
        /// Crea una Payments
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Payments creada</returns>
        public async Task<bool> CreateAsync(Payments data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Payments.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Actualiza los datos de una Payments
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Payments data)
        {
            try
            {
                var entity = await _context.Payments.FindAsync(id);
                if (entity != null)
                {
                    entity.Order_Id = id;
                    entity.Date = DateTime.Now;
                    entity.Amount = data.Amount;
                    entity.Payment_Method = data.Payment_Method;
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
        public ICollection<Payments> GetPayments()
        {
            throw new NotImplementedException();
        }
    }
}
