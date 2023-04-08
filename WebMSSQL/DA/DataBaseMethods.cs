using WebMSSQL.BA;
using WebMSSQL.Models;
using WebMSSQL.Models.entities;

namespace WebMSSQL.DA
{
    public class DataBaseMethods : IDataBaseMethods
    {
        private ProjectContext db = new ProjectContext();

        public Resourses GetResourse(int Id) => db.resourses
            .FirstOrDefault(x => x.Id == Id) ?? MockObjects.resourse;


        public List<Resourses> GetResourses(int categoryId) => db.resourses.Where(x => x.CategoryId == categoryId).ToList();


        public List<Resourses> GetResourses() => db.resourses.ToList();


        public List<Categories> GetCategories() => db.categories.ToList();


        public Categories GetCategories(int categoryId) => db.categories
            .FirstOrDefault(x => x.Id == categoryId) ?? MockObjects.category;


        public List<Resourses> SearchResourses(string name) => db.resourses
            .Where(x => x.name == name).ToList();


        public Resourses GetRandomResourse()
        {
            Random rand = new Random();
            int toSkip = rand.Next(1, db.resourses.Count());

            return db.resourses.Skip(toSkip).Take(1).FirstOrDefault();
        }


        public bool IsLoginAlreadyExcist(string login) => (db.users
            .FirstOrDefault(x => x.Login == login) ?? MockObjects.user) != MockObjects.user ? true : false;


        public bool IsLoginFree(string login) => (db.users
            .FirstOrDefault(x => x.Login == login) ?? MockObjects.user) == MockObjects.user ? true : false;



        public bool Login(string login, string password) =>  IsLoginAlreadyExcist(login) ?
           HashPassword.Verify(db.users.First(x => x.Login == login).PasswordHash, password) : false;

        public  User GetUser(string login) => db.users.FirstOrDefault(x => x.Login == login);

        public async Task<bool> Registration(User user)
        {
            await db.users.AddAsync(user);
            await db.SaveChangesAsync();
            return true;
        }


        public bool IsLoginCorrect(string login) => login.Trim().Length > 3 ? true : false;


    }
}
