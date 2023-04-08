using System.ComponentModel.DataAnnotations;

namespace WebMSSQL.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Укажите имя")]
        [MaxLength(10, ErrorMessage ="Длина логина максимум 10 символов")]
        [MinLength(3, ErrorMessage ="Длина логина минимум 3 символа")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Укажите пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введите код")]
        public string TelegramCode { get; set; }
    }
}
