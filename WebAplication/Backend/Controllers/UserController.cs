using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAplicacion.DTo;
using WebAplicacion.Model;
using WebAplicacion.Services;

namespace WebAplicacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;

        public UserController(IUserServices userServices, IConfiguration configuration)
        {
            _userServices = userServices;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize(Roles = Usertype.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userServices.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(new { Message = "Validation Failed", Errors = errors });
            }

            await _userServices.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedUser = await _userServices.GetUserByIdAsync(id);
            if (updatedUser == null)
            {
                return NotFound();
            }
            await _userServices.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var User = await _userServices.GetUserByIdAsync(id);
            if (User == null)
                return NotFound();

            await _userServices.SoftDeleteUserAsync(id);
            return NoContent();

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginUser)
        {
            // Validar los campos requeridos
            if (string.IsNullOrEmpty(loginUser.Email) || string.IsNullOrEmpty(loginUser.Password))
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Email y contraseña son obligatorios."
                });
            }

            // Verificar las credenciales
            var user = await _userServices.LoginAsync(loginUser.Email, loginUser.Password);

            if (user == null)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Credenciales incorrectas."
                });
            }

            // Generar token JWT
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim (JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim("userType", user.Usertype.Name)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signIn
            );

            return Ok(new
            {
                success = true,
                message = "Inicio de sesión exitoso.",
                token = new JwtSecurityTokenHandler().WriteToken(token),
                user = new
                {
                    id = user.Id,
                    name = user.Name,
                    email = user.Email,
                    userType = user.Usertype.Name
                }
            });
        }
    }
}