using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();

        }
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
            
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);

            if (existingUser == null)
            {
                throw new NotFoundException("User not found");
            }

            // Actualiza las propiedades según sea necesario
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Date = user.Date;
            existingUser.IsDeleted = user.IsDeleted;
            existingUser.Modified = user.Modified;
            existingUser.ModifiedBy = user.ModifiedBy;

            existingUser.Usertype = user.Usertype;


            _context.Entry(existingUser).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<User> GetLoginUser(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Usertype) // Incluir tipo de usuario si es necesario
                .FirstOrDefaultAsync(s => s.Email == email && !s.IsDeleted);

        }
    }
}

