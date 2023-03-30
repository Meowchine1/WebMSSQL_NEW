using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace WebMSSQL.Models
{
    //  (db.users
           // .FirstOrDefault(x => x.Login == login) ?? MockObjects.user) == MockObjects.user? true : false;
    public static class DbData
    {
        private static ProjectContext db = new ProjectContext();


        public static Resourses GetResourse(int Id) => db.resourses
            .FirstOrDefault(x => x.Id == Id) ?? MockObjects.resourse;


        public static List<Resourses> GetResourses(int categoryId) => db.resourses.Where(x => x.CategoryId == categoryId).ToList();


        public static List<Resourses> GetResourses() => db.resourses.ToList();


        public static List<Categories> GetCategories() => db.categories.ToList();


        public static Categories GetCategories(int categoryId) => db.categories
            .FirstOrDefault(x => x.Id == categoryId) ?? MockObjects.category;


        public static List<Resourses> SearchResourses(string name) => db.resourses
            .Where(x => x.name == name).ToList();


        public static Resourses GetRandomResourse()
        {
            Random rand = new Random();
            int toSkip = rand.Next(1, db.resourses.Count());

            return db.resourses.Skip(toSkip).Take(1).FirstOrDefault();
        }


        public static bool IsLoginAlreadyExcist(string login) => (db.users
            .FirstOrDefault(x => x.Login == login) ?? MockObjects.user) != MockObjects.user ? true : false;


        public static bool IsLoginFree(string login) => (db.users
            .FirstOrDefault(x => x.Login == login) ?? MockObjects.user) == MockObjects.user ? true : false;



        public static bool Login(string login, string password) => IsLoginAlreadyExcist(login) ?
            HashPassword.Verify(db.users.First(x => x.Login == login).PasswordHash, password) : false;


        public static void Registration(string login, string password)
        {
            string passwordHash = HashPassword.CreatePasswordHash(password);
            db.users.Add(new User(login, passwordHash, UserRole.DEFAULT));
            db.SaveChanges();

        }

        public static bool IsLoginCorrect(string login) => login.Trim().Length > 3 ? true : false;


    }
}

