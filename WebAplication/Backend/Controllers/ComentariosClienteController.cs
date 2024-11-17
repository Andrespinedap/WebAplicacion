using Microsoft.AspNetCore.Mvc;
using WebAplicacion.Abstractions;
using WebAplicacion.Model;

namespace WebAplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosClienteController : ControllerBase
    {
        /// <summary>
        /// Implementa los metodos de comunicación para interactuar con la base de datos
        /// </summary>
        private readonly IComentariosClientesRepository repository;
        /// <summary>
        /// Logger para registrar en consola algun error o estados success
        /// </summary>
        private readonly ILogger<ComentariosClienteController> logger;

        /// <summary>
        /// Constructor para la clase <see cref="ComentariosClienteController"/>
        /// </summary>
        /// <param name="repository"></param>
        public ComentariosClienteController(IComentariosClientesRepository repository, ILogger<ComentariosClienteController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Servicio encargado de consultar todos los registros
        /// </summary>
        /// <returns>Retorna todos los registros</returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> all()
        {
            try
            {
                // Asignamos la información consultada a una variable
                var data = await this.repository.AllAsync();

                this.logger.LogDebug("Consultando todos los {registros}", data);

                // Validamos que la data no sea null o de otro tipo
                if (data == null || !data.Any())
                {
                    return Ok(new List<object>()); // Devuelve una lista vacía
                }


                return Ok(data);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error al consultar los registros.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");
            }
        }


        /// <summary>
        /// Servicio encargado de consultar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Find(int id)
        {
            //Validamos que el id no sea menor a 0
            if (id < 0)
                return NotFound("Arguments invalids");

            //Retornamos la el resultado de la busqueda
            var result = await repository.FindAsync(id);
            return Ok(result);
        }/// <summary>
         /// Servicio encargado de agregar una respuesta a un comentario existente
         /// </summary>
         /// <param name="id">ID del comentario al cual se le agregará la respuesta</param>
         /// <param name="response">Texto de la respuesta</param>
         /// <returns>Resultado de la operación</returns>
        [HttpPost]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddResponse(int id, [FromBody] string response)
        {
            if (id < 0)
                return NotFound("Invalid comment ID");
            if (string.IsNullOrWhiteSpace(response))
                return NotFound("Response is not valid");

            // Llama a un método del repositorio para agregar la respuesta
            var success = await repository.AddResponseAsync(id, response);

            if (!success)
            {
                return NotFound("Failed to add response to the comment");
            }

            this.logger.LogDebug("Added response to comment - [Id: {Id}, Response: {Response}]", id, response);
            return Ok(success);
        }
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ComentariosClientes comentario)
        {
            if (comentario == null)
                return BadRequest("Comentario no válido");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Esto devolverá los errores de validación al cliente
            }

            var success = await repository.CreateAsync(comentario);

            if (!success)
            {
                logger.LogError("Error al crear el comentario: {Comentario}", comentario);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el comentario");
            }

            logger.LogInformation("Comentario creado exitosamente: {Comentario}", comentario);
            return Ok(success);
        }


        /// <summary>
        /// Servicio encargado de la actualización de un registro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns>Retorna true si fue exitoso de lo contrario un false</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, ComentariosClientes data)
        {
            if (id < 0)
                return NotFound("id is not valid");
            if (data == null)
                return NotFound("Data is not valid");

            var success = await repository.UpdateAsync(id, data);

            // Registra la información de la actualización
            this.logger.LogDebug("Actualizando registro - [Id: {Id}, Success: {Success}, Data: {Data}]", id, success, data);

            // Devuelve el resultado de la actualización
            if (!success)
            {
                return NotFound("Record not found or could not be updated");
            }

            return Ok(success);
        }
    }
}
