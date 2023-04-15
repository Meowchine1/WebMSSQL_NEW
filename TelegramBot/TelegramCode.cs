using System.ComponentModel.DataAnnotations;

namespace TelegramBot
{
    public class TelegramCode
    {
        [Key]
        public int Id { get; set; }
        public string chatId  { get; set; }
        public string code { get; set; } 

        public TelegramCode(string chatId, string code)
        {
            this.chatId = chatId;
            this.code = code;
        }

        public TelegramCode()
        {
        }
    }
}
