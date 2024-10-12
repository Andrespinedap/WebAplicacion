using WebAplicacion.Context;
using WebAplicacion.Interfaces;
using WebAplicacion.Model;


namespace WebAplicacion.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TestDbContext _context;

        public UserRepository(TestDbContext context) 
        {
            _context = context;
        }

        public Task<List<User>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(User data)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<User>GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }

        public Task<bool> UpdateAsync(int id, User data)
        {
            throw new NotImplementedException();
        }

        public User UserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User UserByPassword(string password)
        {
            throw new NotImplementedException();
        }

        public User UserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public bool UserExits(int Userid)
        {
            return _context.Users.Any(p => p.Id == Userid);
        }
    }
}
