using FRNSWSocialLogin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Facebook;

namespace FRNSWSocialLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your Application Page";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task Login()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });


        }




        //    public IActionResult Login()
        //{
        //    var properties = new AuthenticationProperties
        //    {
        //        RedirectUri = RedirectToAction("Index", "Callback").ToString()        
        //    };

        //    return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        //}


        public async Task<IActionResult> GoogleReponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value

            });
            return Json(claims);

        }


        //public async Task<IActionResult> Callback()
        //{
        //    var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    var claims = authenticateResult.Principal.Claims;
        //    // Use the claims for further processing or user registration.

        //    return RedirectToAction("Index", "Home");
        //}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        //public IActionResult FbLogin()
        //{
        //    var properties = new AuthenticationProperties
        //    {
        //        RedirectUri = Url.Action("FacebookResponse")
        //    };

        //    return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        //}

        //public async Task<IActionResult> FacebookResponse()
        //{
        //    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
        //    {
        //        claim.Issuer,
        //        claim.OriginalIssuer,
        //        claim.Type,
        //        claim.Value

        //    });
        //    return Json(claims);

        //}

        //public async Task<IActionResult> Callback()
        //{
        //    var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    var claims = authenticateResult.Principal.Claims;
        //    // Use the claims for further processing or user registration.

        //    return RedirectToAction("Index", "Home");
        //}



    }
}