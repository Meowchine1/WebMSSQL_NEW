using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMSSQL.Models;
using System.Diagnostics;
using TelegramBot;
namespace NorilskNikel.Controllers
{
    public class NornikelController : Controller
    {

        public IActionResult Registration(string login, string password, string repeatPassword, string telegramCode) 
        {

            if (password.Equals(repeatPassword)) {

                if (DbData.IsLoginFree(login) && DbData.IsLoginCorrect(login)) 
                {

                    string realCode = DbConnection.getUserCode();
                    if (realCode.Equals(telegramCode)) 
                    {
                        DbData.Registration(login, password);

                        ViewBag.Categories = DbData.GetCategories();

                        return View("Index");
                    }
                    
                }
                 
            }
            return Redirect("/Start/StartUp");

        }

        public IActionResult Login(string login, string password)
        {
            ViewBag.Categories = DbData.GetCategories();
            return DbData.Login(login, password) ? View("Index") : View("Startup");
        }       
        
        public IActionResult Index(int categoryId)
        {

            ViewBag.Categories = DbData.GetCategories();
        

            if (categoryId == 0)
            {
                ViewBag.Resourses = DbData.GetResourses();
            }
            else
            {
                ViewBag.Resourses = DbData.GetResourses(categoryId);

            }

            return View();
        }


        public IActionResult Resourse(int Id) {

            Resourses r = DbData.GetResourse(Id);
            if (r == MockObjects.resourse)
            {
                return NotFound();
            }

            ViewBag.Categories = DbData.GetCategories();
            ViewBag.Resourse = r;

            return View();
           
        }   


        public IActionResult CategoryResourses(int Id) {

            Categories category = DbData.GetCategories(Id);
 
            if (category == MockObjects.category)
            {
                return NotFound();
            }

            ViewBag.Category = category;
            ViewBag.Categories = DbData.GetCategories();
            ViewBag.Resourses = DbData.GetResourses(Id);

            return View();
           
        }  


        public IActionResult BuyProduct(int Id) {
            Resourses r = DbData.GetResourse(Id);
            if (r == MockObjects.resourse)
            {
                return NotFound();
            }
            ViewBag.Categories = DbData.GetCategories();
            ViewBag.Resourse = r;
            return View("BuyProduct");
          
        }

        public IActionResult Buy() 
        {
            return View("Index");
        }


        [HttpPost]
        public IActionResult Search(string request) {

            if (request == null)
            {
                ViewBag.flag = false;
                ViewBag.Categories = DbData.GetCategories();
            }
            else
            {
                var result = DbData.SearchResourses(request.ToLower());
                ViewBag.result = result;
                ViewBag.flag = (result.Count() != 0)? true : false ;
                ViewBag.Categories = DbData.GetCategories();
            }

            return View();
           
        }


        public Resourses BestResourses() => DbData.GetRandomResourse();
     
    }
}