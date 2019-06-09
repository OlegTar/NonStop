using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Web;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string redirectUri, string sessionId)
        {
            //SignOut();
            HttpContext.Items.Add("sessionId", sessionId);
            var authProperties = new AuthenticationProperties(new Dictionary<string, string>() {
                {"sessionId", sessionId }
            }) {
                RedirectUri = redirectUri
            };
            return Challenge(authProperties);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
