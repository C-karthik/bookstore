using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBookStore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LogHere()
        {
            ViewBag.msg = TempData["message"];
            return View();
        }
        [HttpPost]
        public ActionResult LogHere(string username, string password)
        {
            if (username.Equals("Admin") && password.Equals("Admin"))
            {
                TempData["message"] = username;
                TempData.Keep();
                return RedirectToAction("BookStore", "BookStoreMVC");
            }
            else if (username.Equals("User") && password.Equals("User"))
            {
                TempData["message"] = username;
                TempData.Keep();
                return RedirectToAction("User", "BookStoreMVC");
            }
            else
            {
                TempData["message"] = "Invalid Credentials";
                return RedirectToAction("Login");
            }
        }
    }
}