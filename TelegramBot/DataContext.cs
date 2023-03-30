using Microsoft.EntityFrameworkCore;

namespace TelegramBot
{
    public class DataContext : DbContext
    {

        public DbSet<TelegramCode> telegramCodes { get; set; }

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
              : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnConfiguring(DbContextOptionsBuilder
               optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=telegramVerification;Trusted_Connection=True;TrustServerCertificate=True;");
        }


        public void CreateIfNotExist()
        {
            Database.EnsureCreated();

        }

      
        }
}