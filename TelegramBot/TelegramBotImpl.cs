using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using System.Runtime.CompilerServices;
using System.Data.Common;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TelegramBot
{
    public static class TelegramBotImpl
    {
        private static ITelegramBotClient _bot = new TelegramBotClient("5765340660:AAFjuHk43EfzU4hp_TSXaxffTytynaKAWTo");

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message;
               
                CodeGenerator codeGenerator = new CodeGenerator();
                string code = codeGenerator.getCode();
                if (message.Text.ToLower() == "/authcode")
                {
                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat,
                        text: code);
                    DbConnection.makeUserCodeRecord(message.Chat.ToString(), code);

                    return;
                }
           
            }
        }



        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Данный Хендлер получает ошибки и выводит их в консоль в виде JSON
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Запущен бот " + _bot.GetMeAsync().Result.FirstName);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // разрешено получать все виды апдейтов
            };
            _bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
       
                 
          
           
         

        }
    }
}