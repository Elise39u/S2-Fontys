using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KillerAppS2.Models;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace KillerAppS2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult PostChoice()
        {
            if(Request.Method == "POST")
            {
                List<KeyValuePair<string, string>> postDataList = new List<KeyValuePair<string, string>>();
                //ViewData["PostData"] = Request.Form;
                foreach(var testData in Request.Form)
                {
                    postDataList.Add(new KeyValuePair<string, string>(testData.Key, testData.Value));
                }
                //Session["KeyData"] = (ISession)postDataList;
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        /*
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
