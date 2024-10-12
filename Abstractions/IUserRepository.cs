using WebAplicacion.Model;

namespace WebAplicacion.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        
        User GetUser(int id);
        User UserByEmail(string email);
        User UserByUsername(string username);
        User UserByPassword(string password);
        bool UserExits(int Userid);

    }
}
