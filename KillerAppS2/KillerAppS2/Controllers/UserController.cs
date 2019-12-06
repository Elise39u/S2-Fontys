using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KillerAppS2.Models;
using KillerAppS2Logic;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppS2.Controllers
{
    public class UserController : Controller
    {
        readonly UserLogic userLogic = new UserLogic();
        
        public IActionResult Index()
        {
            foreach(var testSession in HttpContext.Session.Keys)
            {
                ViewData["SessionData"] += " " + testSession;
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckLoginData()
        {
            if (ModelState.IsValid)
            {
                UserViewModel userViewModel = new UserViewModel
                {
                    Email = Request.Form["Email"],
                    Password = Request.Form["Password"]
                };
                userLogic.Login(userViewModel.Email, userViewModel.Password);
            }
           return View("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}