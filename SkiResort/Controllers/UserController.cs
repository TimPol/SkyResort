using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkiResort.Models;
using SkiResort.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace SkiResort.Controllers
{
//Используется для регистрации пользователя и редактирования информации. Использует View Registration
    public class UserController : Controller
    {
        private SkiResortContext _context;
        public UserController(SkiResortContext context) // Конструктор контроллера. Экземляр context приходит с помощью IoC Container зарегестрированный в Startup
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(UserViewModel userViewModel)
        {
            User user = new User 
            {
                Name = userViewModel.Name, 
                Email = userViewModel.Email, 
                Password = userViewModel.Password
            };
            Validate(userViewModel);
            if(ModelState.ErrorCount > 0)
            {
                return View(userViewModel);
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Registration","User");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);
                if (user != null)
                {
                    //await Authenticate(loginViewModel.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(loginViewModel);
        }
        //private async Task Authenticate(string userName)
        //{
        //    // создаем один claim
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
        //    };
        //    // создаем объект ClaimsIdentity
        //    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //    // установка аутентификационных куки
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        //}
        private void Validate(UserViewModel userViewModel) //Метод валидации
        {
            if(userViewModel.Password != userViewModel.ConfirmPassword)
            {
                ModelState.AddModelError(nameof(userViewModel.ConfirmPassword), "Пароли не соовпадают");
            }
            if(_context.Users.Any(x => x.Name == userViewModel.Name && x.Id != userViewModel.Id))
            {
                ModelState.AddModelError(nameof(userViewModel.Name), "Пользователь с таким именем уже существует");
            }
            if(_context.Users.Any(x => x.Email == userViewModel.Email && x.Id != userViewModel.Id))
            {
                ModelState.AddModelError(nameof(userViewModel.Email), "Данная почта уже занята");
            }
        }
    }
}