﻿using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        private readonly TestDbContext _context;
        /// <summary>
        /// Constructor de la clase <see cref="ClientRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public OrdersRepository(TestDbContext context) 
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una Client por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Client</returns>
        public async Task<Order> FindAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Clients
        /// </summary>
        /// <returns>Retorna toda la data de las Clients</returns>

        public Task<List<Order>> AllAsync()
        {
            return _context.Orders.ToListAsync();
        }
        /// <summary>
        /// Crea una Client
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Client creada</returns>
        public async Task<bool> CreateAsync(Order data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await _context.Orders.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Actualiza los datos de una Client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, Order data)
        {
            try
            {
                var entity = await _context.Orders.FindAsync(id);
                if (entity != null)
                {
                    entity.Vehicle_Id = id;
                    entity.Employee_Id = data.Employee_Id;
                    entity.DateCreated = DateTime.Now;

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
        public ICollection<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
