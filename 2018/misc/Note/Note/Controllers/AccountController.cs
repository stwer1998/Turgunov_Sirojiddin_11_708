using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note.Models;

namespace Note.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext db;
        public AccountController(MyDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            User user = db.Users.FirstOrDefault(x => x.Login == model.Login && x.Password == model.Password);
            if (user != null)
            {
                await Authenticate(model.Login); // аутентификация

                return RedirectToAction("Main", "MyNote");
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            User user = db.Users.FirstOrDefault(u => u.Login == model.Login);
            if (user == null)
            {
                db.Users.Add(new User { Login = model.Login, Password = model.Password});
                db.SaveChanges();
                await Authenticate(model.Login); // аутентификация

                return RedirectToAction("Main", "MyNote");
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