using Bank_MVC_App.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Bank_MVC_App.Services
{
    public interface IUserOps
    {
        ICollection<User> GetAllUsers();
        User GetUserById(int UserId);
        User AddUser(User NewUser);
        User UpdateUser(int UserId, User user);
        User DeleteUser(int UserId);
    }
}
