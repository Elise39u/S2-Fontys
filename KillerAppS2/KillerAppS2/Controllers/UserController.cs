using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KillerAppS2.Models;
using KillerAppS2DTO;
using KillerAppS2Logic;
using Microsoft.AspNetCore.Http;
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
            HttpContext.Session.SetString("PageChoice", ViewData["SessionData"].ToString());
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckLoginData()
        {
            if (ModelState.IsValid && Request.Form["Email"] != "" && Request.Form["Password"] != "")
            {
                UserViewModel userViewModel = new UserViewModel
                {
                    Email = Request.Form["Email"],
                    Password = Request.Form["Password"]
                };
                UserDTO DataBaseUser = userLogic.Login(userViewModel.Email, userViewModel.Password);
                UserViewModel user = new UserViewModel
                {
                    Email = DataBaseUser.Email,
                    Username = DataBaseUser.Username,
                    Attack = DataBaseUser.Attack,
                    Defence = DataBaseUser.Defence,
                    CurHP = DataBaseUser.CurHP,
                    MaxHP = DataBaseUser.MaxHP,
                };
                HttpContext.Session.SetObjectAsJson("User", user);
                return ChooseNextPage();
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult ChooseNextPage()
        {
            string choice = HttpContext.Session.GetString("PageChoice");
            HttpContext.Session.SetString("PageChoice", "");

            return ChooseNextPage(choice);
        }

        private IActionResult ChooseNextPage(string choice)
        {
            if (choice == "Play")
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("Index", "Template");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckRegisterData()
        {
            if (ModelState.IsValid)
            {
                UserViewModel userViewModel = new UserViewModel
                {
                    FirstName = Request.Form["FirstName"],
                    Prefix = Request.Form["Prefix"],
                    LastName = Request.Form["LastName"],
                    Email = Request.Form["Email"],
                    Password = Request.Form["Password"]
                };
                string result = userLogic.Register(userViewModel.Email, userViewModel.FirstName, userViewModel.Prefix, userViewModel.LastName, userViewModel.Password);
                SetViewData(result);
            }

            return View("Index");
        }

        private static void SetViewData(string result)
        {
            if (result == "")
            {

            }
            else
            {

            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}