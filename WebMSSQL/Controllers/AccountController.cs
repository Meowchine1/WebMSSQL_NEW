using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMSSQL.Models;
using TelegramBot;
using WebMSSQL.Models.entities;
using WebMSSQL.BA;

namespace WebMSSQL.Controllers
{
    public class AccountController : Controller
    {
        BuisnessService service = new BuisnessService(); 
       
        [HttpGet]
        public IActionResult Register() => View(); // what

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var response = await service.Registration(model.Login, model.Password, model.TelegramCode);
                if (response.StatusCode == BA.StatusCode.OK)
                {
                    var data = response.Data;
                    var user = HttpContext.User.Identity;
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));
                 
                 
                    return RedirectToAction("Index", "Nornikel");
                
                }
                ModelState.AddModelError("", response.Description);
            }
            return View("~/Views/Norniel/Index.cshtml", model);
           
        }

        [HttpGet]
        public IActionResult Login() => View();
     
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await service.Login(model.Login, model.Password);
                if (response.StatusCode == BA.StatusCode.OK) {

                    var data = response.Data;
                    string message = "";
                    foreach (var el in data.Claims) {

                        message += el.Value.ToString() +" ";
                    }
                  
                    // HttpContext.Session.SetString("username", model.Login);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(response.Data));
                    return RedirectToAction("Index", "Nornikel");

                }

                ModelState.AddModelError("", response.Description);
            }
            return View(model);
        }

        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return View();
        //}


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

    }
}

