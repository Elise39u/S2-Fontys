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

        public IActionResult Index(List<KeyValuePair<string, string>> keyCheck)
        {
            keyCheck.ForEach(
                    x =>
                    {
                        if(x.Key == "Make")
                        {
                            KeyCheck = "Makeing/Editing";
                        }
                        else if(x.Key == "Play")
                        {
                            KeyCheck = "Gameing";
                        }
                        else
                        {
                            Error();
                        }
                    }
                );
            ViewData["Key"] = KeyCheck;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}