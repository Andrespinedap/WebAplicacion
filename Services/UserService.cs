using Microsoft.EntityFrameworkCore;
using WebAplicacion.Context;
using WebAplicacion.Interfaces;
using WebAplicacion.Model;
using WebAplicacion.Repositories;

namespace WebAplicacion.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _userRepository.CreateUserAsync(user);

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();

        }

        public async Task<User> LoginAsync(string email, string password)
        {
            // Buscar el usuario por correo electrónico
            var user = await _userRepository.GetLoginUser(email);

            // Verificar si el usuario existe y no está eliminado
            if (user == null || user.IsDeleted)
            {
                return null; // Usuario no encontrado o está eliminado
            }

            try
            {
                // Verificar la contraseña encriptada
                if (string.IsNullOrEmpty(user.Password) || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return null; // Contraseña incorrecta
                }
            }
            catch (BCrypt.Net.SaltParseException ex)
            {
                // Log de la excepción para entender mejor el problema
                Console.WriteLine("Error al verificar el hash de la contraseña: " + ex.Message);
                return null; // Hash o salt inválido
            }

            return user; // Retornar el usuario si las credenciales son correctas
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            await _userRepository.SoftDeleteUserAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
