using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebMSSQL.Models
{
    
    public class User
    {
        public int Id { get; set; }
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]
      //  [Remote(action: "CheckLogin", controller: "Start", ErrorMessage = "login уже используется")]
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public UserRole userRole { get; set; }

        public User(string login, string passwordHash, UserRole userRole)
        {
            Login = login;
            PasswordHash = passwordHash;
            this.userRole = userRole;
        }

        public User()
        {
        }
    }
}
