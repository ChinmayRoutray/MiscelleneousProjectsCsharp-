using Bank_MVC_App.Entity;
using Bank_MVC_App.Models;

namespace Bank_MVC_App.Services
{
    public class UserOps : IUserOps
    {
        public readonly BankDbContext _context;

        public UserOps(BankDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ICollection<User> GetAllUsers()
        {
            return _context.AllUsers.ToList();
        }

        public User GetUserById(int UserId) 
        {
            return _context.AllUsers.Where(c => c.UserId == UserId).FirstOrDefault();
        }

        public User AddUser(User user)
        {
            _context.AllUsers.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(int id, User user)
        {
            var query = _context.AllUsers.Where(c => c.UserId == id).FirstOrDefault();
            if(query != null)
            {
                query.UserName = user.UserName;
                query.Password = user.Password;
                _context.SaveChanges();
            }
            return query;
        }

        public User DeleteUser(int id)
        {
            var query = _context.AllUsers.Where(c => c.UserId == id).FirstOrDefault();
            if(query != null)
            {
                _context.AllUsers.Remove(query);
                _context.SaveChanges();
            }
            return query;
        }
    }
}
