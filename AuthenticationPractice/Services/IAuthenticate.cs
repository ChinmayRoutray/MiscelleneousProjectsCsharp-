using AuthenticationPractice.Models;

namespace AuthenticationPractice.Services
{
    public interface IAuthenticate
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        string GetToken(string username, string password);
    }
}
