using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebAplicacion.Abstractions;
using WebAplicacion.Interfaces;
using WebAplicacion.Model;
using WebAplicacion.Repositories;

namespace WebAplicacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserHistoryController : ControllerBase
    {
        private readonly IUserHistoryRepository _userHistoryRepository;
        public UserHistoryController(IUserHistoryRepository userHistoryRepository)
        {
            _userHistoryRepository = userHistoryRepository;
        }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UsersHistory>>> GetAllUserHistory()
    {
        var userHistory = await _userHistoryRepository.GetAllUserHistoryAsync();
        return Ok(userHistory);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UsersHistory>> GetUserGetUserHistoryById(int id)
    {
        var userHistory = await _userHistoryRepository.GetUserHistoryByIdAsync(id);
        if (userHistory == null)
        {
            return NotFound();
        }
        return Ok(userHistory);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UsersHistory>> CreateUserHistory([FromBody] UsersHistory userHistory)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        
        }
        var newuserHistory = await _userHistoryRepository.CreateUserHistoryAsync(userHistory);
        return CreatedAtAction(nameof(GetUserGetUserHistoryById), new { id = newuserHistory.Id }, newuserHistory);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUserHistory(int id, [FromBody] UsersHistory userHistory)
    {
        if (ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateUserHistory = await _userHistoryRepository.UpdateUserHistoryAsync(userHistory);
        if (updateUserHistory == null)
        {
                return NotFound();
        }
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task <IActionResult> DeleteUserHistory(int id)
    {
        await _userHistoryRepository.DeleteUserHistoryAsync(id);
        return NoContent();
    }
  }
}