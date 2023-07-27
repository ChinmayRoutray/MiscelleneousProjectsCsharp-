using AuthenticationPractice.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationPractice.Services
{
    public class Authenticate : IAuthenticate
    {
        private readonly UsersContext _context;
        private readonly IConfiguration _configuration;
        public string? tok { get; set; }
        public Authenticate(UsersContext context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(_configuration));
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(c => c.Id == id).FirstOrDefault();
        }
        public string GetToken(string username, string password)
        {
            var res = _context.Users.Where(c => c.Name == username && c.Password == GetHashString(password)).FirstOrDefault();
            if (res == null)
            {
                return null;
            }
            
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsforToken = new List<Claim>();
            claimsforToken.Add(new Claim("sub", res.Id.ToString()));
            claimsforToken.Add(new Claim("user", res.Name));
            claimsforToken.Add(new Claim("email", res.Email));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsforToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            //Authenticate.tok = token;
            return token;
        }
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
