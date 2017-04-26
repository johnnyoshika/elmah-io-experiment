using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ElmahIoExperiment
{
    public class HomeController : Controller
    {
        public IActionResult Index(bool throw400 = false, bool throw500 = false)
        {
            if (throw400)
                throw new ArgumentException();

            if (throw500)
                throw new InvalidOperationException();

            return Json(new { Message = "Hello!!!" });
        }
    }
}
