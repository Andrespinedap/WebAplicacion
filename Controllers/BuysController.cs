using Microsoft.AspNetCore.Mvc;
using WebAplicacion.Abstractions;
using WebAplicacion.Model;

namespace WebAplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuysController : ControllerBase
    {
        /// <summary>
        /// Implementa los metodos de comunicación para interactuar con la base de datos
        /// </summary>
        private readonly IBuysRepository repository;
        /// <summary>
        /// Logger para registrar en consola algun error o estados success
        /// </summary>
        private readonly ILogger<BuysController> logger;

        /// <summary>
        /// Constructor para la clase <see cref="BuysController"/>
        /// </summary>
        /// <param name="repository"></param>
        public BuysController(IBuysRepository repository, ILogger<BuysController> logger)
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
            // Asigmnamos la información consultada a una variable
            var data = await this.repository.AllAsync();

            this.logger.LogDebug("Consultando todos los {registros}", data);

            // Validamos que la data no se null o de otro tipo
            if (data == null || !data.Any())
            {
                return NotFound("No records found.");
            }

            return Ok(data);

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
        }
        /// <summary>
        /// Servicio encargado de crear una Buys
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el Id de la compañia</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(Buys data)
        {
            // Validamos que la data no sea nula
            if (data == null)
                return NotFound("Arguments invalids");

            // Creamos una compañia
            var dataCreate = await this.repository.CreateAsync(data);

            // Verifica si la creación fue exitosa (si la creación retorna algún valor que indique éxito)
            if (!dataCreate)
            {
                return NotFound("Failed to create the record");
            }

            this.logger.LogDebug("Creando registro - [Data: {data}]", data);
            return Ok(dataCreate);
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
        public async Task<IActionResult> Update(int id, Buys data)
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
