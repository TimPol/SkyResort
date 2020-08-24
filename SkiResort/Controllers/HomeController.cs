using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SkiResort.Controllers
{
    //Контроллер для стартовой страницы использует View Index
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}