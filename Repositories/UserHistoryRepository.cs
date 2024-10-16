using WebAplicacion.Abstractions;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class UserHistoryRepository : IUserHistoryRepository
    {
        public Task<List<UsersHistory>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(UsersHistory data)
        {
            throw new NotImplementedException();
        }

        public Task<UsersHistory> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<UsersHistory> GetUserHistories()
        {
            throw new NotImplementedException();
        }

        public object GetUserHistory(int userHistoryid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UsersHistory data)
        {
            throw new NotImplementedException();
        }

        public bool UserHistoryExits(int UserHistoryid)
        {
            throw new NotImplementedException();
        }
    }
}
