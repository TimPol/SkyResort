using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SkiResort.Controllers
{
    public class PlatformController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}