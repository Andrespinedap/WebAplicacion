using WebAplicacion.Model;

namespace WebAplicacion.Interfaces
{
    public interface IUserHistoryRepository
    {
        Task<IEnumerable<UsersHistory>> GetAllUserHistoryAsync();
        Task<UsersHistory> GetUserHistoryByIdAsync(int id);
        Task<UsersHistory> CreateUserHistoryAsync(UsersHistory userHistory);
        Task<UsersHistory> UpdateUserHistoryAsync(UsersHistory userHistory);
        Task DeleteUserHistoryAsync(int id);
    }
}