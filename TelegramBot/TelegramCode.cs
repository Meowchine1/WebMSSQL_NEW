using System.ComponentModel.DataAnnotations;

namespace TelegramBot
{
    public class TelegramCode
    {
        [Key]
        public int Id { get; set; }
        public String login  { get; set; }
        public String code { get; set; } 

        public TelegramCode(string login, string code)
        {
            this.login = login;
            this.code = code;
        }

        public TelegramCode()
        {
        }
    }
}
