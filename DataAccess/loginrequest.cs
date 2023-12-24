using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace DataAccess
{
    public class Account
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        // Change the property name from Password to HashedPassword
        [Required(ErrorMessage = "Password is required")]
        public string HashedPassword { get; set; }

        // Use this method to set the hashed password
        public void SetPassword(string password)
        {
            // Hash the password using SHA256
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                HashedPassword = Convert.ToBase64String(hashedBytes);
            }
        }

    }
}
