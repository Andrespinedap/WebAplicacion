using Microsoft.AspNetCore.Mvc;
using WebAplicacion.Abstractions;
using WebAplicacion.Model;

namespace WebAplicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersRepository repository;
        private ILogger<OrderController> logger;

        public OrderController(IOrdersRepository repository, ILogger<OrderController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> all()
        {
            var data = await this.repository.AllAsync();
            this.logger.LogDebug("Consultando todos los {registros}", data);
            if (data == null || !data.Any())
            {
                return NotFound("No records found.");
            }
            return Ok(data);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Find(int id)
        {
            if (id < 0)
                return NotFound("Arguments invalids");
            var result = await repository.FindAsync(id);
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Create(Order data)
        {
            if (data == null)
                return NotFound("Arguments invalids");
            var dataCreate = await repository.CreateAsync(data);
            if (!dataCreate)
            {
                return NotFound("Failed to create the record");
            }
            logger.LogDebug("Creando registro - [Data: {data}]", data);
            return Ok(dataCreate);
        }
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, Order data)
        {
            if (id < 0)
                return NotFound("id is not valid");
            if (data == null)
                return NotFound("Data is not valid");
            var success = await repository.UpdateAsync(id, data);
            logger.LogDebug("Actualizando registro - [Id: {Id}, Success: {Success}, Order: {Order}]", id, success, data);
            if (success)
            {
                return NotFound("Record not found or could not be updated");
            }
            return Ok(success);
        }
    }
}