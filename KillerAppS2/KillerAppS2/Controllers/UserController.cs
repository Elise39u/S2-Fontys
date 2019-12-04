﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KillerAppS2.Models;
using Microsoft.AspNetCore.Mvc;

namespace KillerAppS2.Controllers
{
    public class UserController : Controller
    {
        public string KeyCheck { get; set; } = "";

        public IActionResult Index()
        {
            if(Request.Method == "POST")
            {
                ViewData["PostCheck"] = "Post appeard";
            }

            foreach(var testSession in HttpContext.Session.Keys)
            {
                ViewData["SessionData"] += " " + testSession;
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