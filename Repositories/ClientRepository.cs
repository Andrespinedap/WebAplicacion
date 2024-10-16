using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class ClientRepository: IClientRepository
    {
        /// <summary>
        /// Servicio que implementa la conexió con la base de datos
        /// </summary>
        public readonly TestDbContext context;

        /// <summary>
        /// Constructor de la clase <see cref="ClientRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public ClientRepository(TestDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Consulta una Client por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una Client</returns>
        public async Task<Client> FindAsync(int id)
        {
            return await this.context.Clients.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las Clients
        /// </summary>
        /// <returns>Retorna toda la data de las Clients</returns>
        public Task<List<Client>> AllAsync()
        {
            return this.context.Clients.ToListAsync();
        }

        /// <summary>
        /// Crea una Client
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la Client creada</returns>
        public async Task<bool> CreateAsync(Client data)
        {
            // Verificar si los datos son válidos
            if (data == null)
            {
                return false; // Retornar false si los datos son nulos
            }

            await this.context.Clients.AddAsync(data);

            // Intentar guardar los cambios y obtener el número de registros afectados
            var result = await this.context.SaveChangesAsync();

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
        public async Task<bool> UpdateAsync(int id, Client data)
        {
            try
            {
                var entity = await this.context.Clients.FindAsync(id);
                if (entity != null)
                {
                    entity.Name = data.Name;
                    entity.Telefono = data.Telefono;
                    entity.Email = data.Email;
                    entity.Direccion = data.Direccion;

                    this.context.Update(entity);

                    return (await this.context.SaveChangesAsync()) > 0;
                }
                return false;

            }
            catch (Exception err)
            {

                throw new InvalidOperationException( "Ha ocurrido un error: " + err);
            }
        }

        public ICollection<Client> GetClients()
        {
            throw new NotImplementedException();
        }
    }
}
