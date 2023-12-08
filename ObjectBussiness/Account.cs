using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace ObjectBussiness
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Account ID")]
        public int AccountID { get; set; }

        [Display(Name = "Exam ID")]
        public int ExamID { get; set; }

        [ForeignKey("ExamRegister")]
        [Display(Name = "Exam Register ID")]
        public int ExamRegisterID { get; set; }

        // Change the property name from Password to HashedPassword
        public string HashedPassword { get; set; }

        [JsonIgnore]
        public virtual Decentralization? Decentralization { get; set; }

        [JsonIgnore]
        public virtual ICollection<News>? News { get; set; }

        [JsonIgnore]
        public virtual Exam? Exam { get; set; }

        [JsonIgnore]
        public virtual ExamRegister? ExamRegister { get; set; }

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

        // Use this method to verify the password
        public bool VerifyPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashedInputPassword = Convert.ToBase64String(hashedBytes);
                return string.Equals(hashedInputPassword, HashedPassword);
            }
        }
    }
}
