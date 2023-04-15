

using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TelegramBot;
using WebMSSQL.DA;
using WebMSSQL.Models.entities;

namespace WebMSSQL.BA
{
    public class BuisnessService
    {
        public IDataBaseMethods dataBaseMethods = new DataBaseMethods();


        public Resourses GetResourse(int Id) => dataBaseMethods.GetResourse(Id);


        public List<Resourses> GetResourses(int categoryId) => dataBaseMethods.GetResourses(categoryId);


        public List<Resourses> GetResourses() => dataBaseMethods.GetResourses();


        public List<Categories> GetCategories() => dataBaseMethods.GetCategories();

        public Categories GetCategories(int categoryId) => dataBaseMethods.GetCategories(categoryId);

        public List<Resourses> SearchResourses(string name) => dataBaseMethods.SearchResourses(name);

        public Resourses GetRandomResourse() => dataBaseMethods.GetRandomResourse();


        public async Task<BaseResponse<ClaimsIdentity>> Login(string login, string password) {

            var user = dataBaseMethods.GetUser(login);

            if (user == null) {

                return new BaseResponse<ClaimsIdentity> { 
                
                    Description="Пользователь не найден"
                };
            }

            if (dataBaseMethods.Login(login, password))
            {
                var result = Authenticate(user);
                return new BaseResponse<ClaimsIdentity> { 
                
                    Data = result,
                    StatusCode = StatusCode.OK

                };

            }
            else {
                return new BaseResponse<ClaimsIdentity>
                {

                    Description = "Неверный пароль"
                };

            }

        }//=> dataBaseMethods.Login(login, password);

        public User GetUser(string login) => dataBaseMethods.GetUser(login);

        public async Task<BaseResponse<ClaimsIdentity>> Registration(string login, string password, string telegramCode)
        {
            if (dataBaseMethods.IsLoginFree(login))
            {

                string realCode = DbConnection.getUserCode();// last code RABBIT MQ
                if (realCode.Equals(telegramCode))
                {
                    User user = new User()
                    {
                        Login = login,
                        PasswordHash = HashPassword.CreatePasswordHash(password),
                        userRole = UserRole.DEFAULT
                    };

                    await dataBaseMethods.Registration(user);
                    var result = Authenticate(user);

                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Data = result,
                        Description = "Аккаунт создан",
                        StatusCode = StatusCode.OK
                    };

                }
                else
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный телеграм-код",
                    };

                }
            }
            else
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь с таким логином уже есть",
                };
            }

        }

        private ClaimsIdentity Authenticate(User user)
        {

            var claims = new List<Claim>() {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.userRole.ToString())
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }



        public bool IsLoginCorrect(string login) => dataBaseMethods.IsLoginCorrect(login);


    }
}