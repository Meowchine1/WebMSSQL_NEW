using WebMSSQL.Models.entities;

namespace WebMSSQL.DA
{
    public interface IDataBaseMethods
    {
        public Resourses GetResourse(int Id);

        public List<Resourses> GetResourses(int categoryId);

        public List<Resourses> GetResourses();

        public List<Categories> GetCategories();

        public Categories GetCategories(int categoryId);

        public List<Resourses> SearchResourses(string name);

        public Resourses GetRandomResourse();

        public bool IsLoginAlreadyExcist(string login);

        public bool IsLoginFree(string login);

        public bool  Login(string login, string password);

        public User GetUser(string login);

        public Task<bool> Registration(User user);

        public bool IsLoginCorrect(string login); 

    }
}
