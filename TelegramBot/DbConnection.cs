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

        public static void makeUserCodeRecord(string login, string code)
        {
            db.telegramCodes.Add(new TelegramCode(login, code));
            db.SaveChanges();
        }


        public static String getUserCode()
        {
            var userRecord = db.telegramCodes.ToList().LastOrDefault();
            return userRecord.code;
        }
    }
}
