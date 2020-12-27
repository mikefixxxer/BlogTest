using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Controllers
{
    public class LoginController : Controller
    {
        
        public string Index2()
        {
            
            return "This is my default action...";
        }

        public IActionResult Index()
        {
            return View();
        }

        public string Welcome2()
        {
            return "This is the Welcome action method...";
        }

        [HttpPost]
        public ActionResult Welcome(Models.LoginModel loguser)
        {

            string user = loguser.User;
            string password = loguser.Password;

            ViewData["Message"] = "Hello " + user;
            ViewData["NumTimes"] = 4;

            return View();
        }
    }
}
