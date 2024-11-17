using Microsoft.EntityFrameworkCore;
using WebAplicacion.Interfaces;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class UserHistoryRepository : IUserHistoryRepository
    {
        private readonly TestDbContext _context;

        public UserHistoryRepository(TestDbContext context) 
        {
            _context = context;
        }
        public async Task<UsersHistory> CreateUserHistoryAsync(UsersHistory userHistory)
        {
            _context.UsersHistory.Add(userHistory);
            await _context.SaveChangesAsync();
            return userHistory;
        }

        public async Task DeleteUserHistoryAsync(int id)
        {
            var usersHistory = await _context.UsersHistory.FindAsync(id);
            if (usersHistory != null)
            {
                _context.UsersHistory.Remove(usersHistory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UsersHistory>> GetAllUserHistoryAsync()
        {
            return await _context.UsersHistory.ToListAsync();
        }

        public async Task<UsersHistory> GetUserHistoryByIdAsync(int id)
        {
            return await _context.UsersHistory.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<UsersHistory> UpdateUserHistoryAsync(UsersHistory userHistory)
        {
            var existingUserHistory = await _context.UsersHistory.FindAsync(userHistory.Id);

            if (existingUserHistory == null)
            {
                throw new NotFoundException("User not found");
            }

            // Actualiza las propiedades según sea necesario
            existingUserHistory.Datecreate = userHistory.Datecreate;
            existingUserHistory.Datemodified = userHistory.Datemodified;

            _context.Entry(existingUserHistory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingUserHistory;
        }
    }
}