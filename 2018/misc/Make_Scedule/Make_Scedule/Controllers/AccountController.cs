using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Make_Scedule.Models;

namespace Make_Scedule.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository unitofwork;
      
        public AccountController()
        {
            unitofwork = new AccountReposirory();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!unitofwork.GetOrganaizer(model.Login, model.Password))
            {
                ModelState.AddModelError("","Пользователь с таким логином и паролем не найден");
            }           
            if (ModelState.IsValid&&unitofwork.GetOrganaizer(model.Login, model.Password))
            {
                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("Events", "Home");
            }        
            
            else return View(model);

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Organizer model)
        {
            //model.CanAddEvent = true;
            if (unitofwork.GetLogin(model.Login))
            {
                ModelState.AddModelError("Login", "Пользователь с таким логином уже есть");
            }
            if(ModelState.IsValid)
            {
                unitofwork.AddOrganaizer(model);
                await Authenticate(model.Login); // аутентификация

                return RedirectToAction("Events", "Home");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}