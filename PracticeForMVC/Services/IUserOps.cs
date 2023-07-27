using PracticeForMVC.Models;

namespace PracticeForMVC.Services
{
    public interface IUserOps
    {
        IEnumerable<User> AllUsers();
        User GetUserById(int id);
        User AddUser(User user);
    }
}
