using PracticeForMVC.Models;

namespace PracticeForMVC.Services
{
    public class UserOps : IUserOps
    {
        private UserDbContext _context;
        public UserOps(UserDbContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> AllUsers()
        {
            return _context.UserLoginFormat.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.UserLoginFormat.Where(c => c.Id == id).FirstOrDefault();
        }

        public User AddUser(User user)
        {
            if(user != null)
            {
                _context.UserLoginFormat.Add(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

    }
}
