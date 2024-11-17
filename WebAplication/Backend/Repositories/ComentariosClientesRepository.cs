using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class ComentariosClientesRepository : IComentariosClientesRepository
    {
        /// <summary>
        /// Servicio que implementa la conexión con la base de datos
        /// </summary>
        public readonly TestDbContext _context;

        /// <summary>
        /// Constructor de la clase <see cref="ComentariosClientesRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public ComentariosClientesRepository(TestDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Consulta una ComentariosClientes por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna una ComentariosClientes</returns>
        public async Task<ComentariosClientes> FindAsync(int id)
        {
            return await _context.ComentariosClientes.FindAsync(id);
        }
        /// <summary>
        /// Obtiene todas las ComentariosClientess
        /// </summary>
        /// <returns>Retorna toda la data de las ComentariosClientess</returns>
        public Task<List<ComentariosClientes>> AllAsync()
        {
            return _context.ComentariosClientes.ToListAsync();
        }

        /// <summary>
        /// Crea una ComentariosClientes
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el id de la ComentariosClientes creada</returns>
        public async Task<bool> CreateAsync(ComentariosClientes data)
        {
            // Verificar si los datos son nulos
            if (data == null)
            {
                return false;
            }

            // Validar propiedades necesarias (por ejemplo, asegurarse de que el comentario no esté vacío)
            if (string.IsNullOrWhiteSpace(data.Comment))
            {
                return false; // Retornar false si el comentario es inválido
            }

            await _context.ComentariosClientes.AddAsync(data);

            // Intentar guardar los cambios
            var result = await _context.SaveChangesAsync();

            // Retornar true si se guardaron los cambios, de lo contrario false
            return result > 0;
        }

        /// <summary>
        /// Actualiza los datos de una ComentariosClientes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true cuando la actualización es satisfactoria, de lo contrario retorna false</returns>
        public async Task<bool> UpdateAsync(int id, ComentariosClientes data)
        {
            try
            {
                var entity = await _context.ComentariosClientes.FindAsync(id);
                if (entity != null)
                {
                    entity.Order_Id = id;
                    entity.Client_Id = id;
                    entity.Comment = data.Comment;
                    entity.Autor = data.Autor;
                    entity.Response = data.Response;
                    entity.Qualification = data.Qualification;
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
        public ICollection<ComentariosClientes> GetComentariosClientes()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> AddResponseAsync(int id, string response)
        {
            var comentario = await _context.ComentariosClientes.FindAsync(id);
            if (comentario == null) return false;

            comentario.Response = response; // Asume que hay un campo "Response" en el modelo `ComentariosClientes`
            _context.ComentariosClientes.Update(comentario);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
