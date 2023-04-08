using Microsoft.AspNetCore.Mvc;
using WebMSSQL.Models.entities;
using WebMSSQL.BA;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace NorilskNikel.Controllers
{
    //   [Authorize]
    public class NornikelController : Controller
    {
        BuisnessService service = new BuisnessService();

        public IActionResult Index(int categoryId)
        {

            ViewBag.Categories = service.GetCategories();
        

            if (categoryId == 0)
            {
                ViewBag.Resourses = service.GetResourses();
            }
            else
            {
                ViewBag.Resourses = service.GetResourses(categoryId);

            }

            return View();
        }


        public IActionResult Resourse(int Id) {

            Resourses r = service.GetResourse(Id);
            if (r == MockObjects.resourse)
            {
                return NotFound();
            }

            ViewBag.Categories = service.GetCategories();
            ViewBag.Resourse = r;

            return View();
           
        }   


        public IActionResult CategoryResourses(int Id) {

            Categories category = service.GetCategories(Id);
 
            if (category == MockObjects.category)
            {
                return NotFound();
            }

            ViewBag.Category = category;
            ViewBag.Categories = service.GetCategories();
            ViewBag.Resourses = service.GetResourses(Id);

            return View();
           
        }  


        public IActionResult BuyProduct(int Id) {
            Resourses r = service.GetResourse(Id);
            if (r == MockObjects.resourse)
            {
                return NotFound();
            }
            ViewBag.Categories = service.GetCategories();
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
                ViewBag.Categories = service.GetCategories();
            }
            else
            {
                var result = service.SearchResourses(request.ToLower());
                ViewBag.result = result;
                ViewBag.flag = (result.Count() != 0)? true : false ;
                ViewBag.Categories = service.GetCategories();
            }

            return View();
           
        }


        public Resourses BestResourses() => service.GetRandomResourse();

    }
}