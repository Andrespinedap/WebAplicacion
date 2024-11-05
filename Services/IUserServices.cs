using WebAplicacion.Model;

namespace WebAplicacion.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
        Task<User> LoginAsync(string email, string password);

    }
}
