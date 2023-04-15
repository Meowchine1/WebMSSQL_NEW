using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public static class DbConnection
    {
        private static DataContext db = new DataContext();

        public static void makeUserCodeRecord(string chatId, string code)
        {
            db.telegramCodes.Add(new TelegramCode(chatId, code));
            db.SaveChanges();
        }


        public static string getUserCode() //
        {
            var userRecord = db.telegramCodes.ToList().LastOrDefault();
            return userRecord.code;
        }

        
    }
}
