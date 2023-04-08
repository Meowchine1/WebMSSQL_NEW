using System.ComponentModel.DataAnnotations;

namespace WebMSSQL.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Введите логин")]
        [MaxLength(10, ErrorMessage = "Логин не более чем из 10 элементов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
