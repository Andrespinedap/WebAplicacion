using WebAplicacion.Model;

namespace WebAplicacion.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task SoftDeleteUserAsync(int id);
        Task<User>GetLoginUser(string email);
    }
}