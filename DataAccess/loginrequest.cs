using Microsoft.EntityFrameworkCore;
using ObjectBussiness;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LoginDAO
    {
        private readonly PetroleumBusinessDBContext _dbContext;
        private static LoginDAO _instance;
        private static readonly object Lock = new object();

        public static LoginDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoginDAO();
                    }
                    return _instance;
                }
            }
        }

        private LoginDAO()
        {
            _dbContext = new PetroleumBusinessDBContext();
        }

        public async Task<bool> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> VerifyPasswordAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);

            if (user != null)
            {
                // Compare the hashed password
                return VerifyHashedPassword(user., password);
            }

            return false;
        }

        // Use this method to verify the hashed password
        private bool VerifyHashedPassword(string hashedPassword, string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashedInputPassword = Convert.ToBase64String(hashedBytes);

                return string.Equals(hashedInputPassword, hashedPassword);
            }
        }
    }
}
