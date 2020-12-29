using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogSystem.Data;
using Microsoft.AspNetCore.Http;

namespace BlogSystem.Controllers
{
    public class LoginController : Controller
    {

        private readonly BlogSystemContext _context;

        public LoginController(BlogSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Verify if password matches Hash and Salt
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        //Sign out: Empty session variables
        public ActionResult _SignOut() {
            
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Profile");
            return RedirectToAction("Index", "Blogs");
        }

        //Check user and password, create session variables and returns list of Blogs
        [HttpPost]
        public ActionResult Welcome(Models.Users loguser)
        {

            string password = loguser.password;

            var user = _context.Users.FirstOrDefault(m => m.user_name == loguser.user_name);
           
            if ((user == null)||(!VerifyPasswordHash(password, user.password_hash, user.password_salt)))
            {
                ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
                return View("Index");
            }
        
            HttpContext.Session.SetInt32("Id", user.id);
            HttpContext.Session.SetString("Username", loguser.user_name);
            HttpContext.Session.SetInt32("Profile", user.profile);

            ViewData["Username"] =  HttpContext.Session.GetString("Username");

            return RedirectToAction("Index", "Blogs");

        }
    }
}
