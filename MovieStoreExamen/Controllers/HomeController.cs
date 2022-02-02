using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreExamen.Models;
using System.Diagnostics;

namespace MovieStoreExamen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ChangeLanguage(string id, string returnUrl)
        {
            string culture = Thread.CurrentThread.CurrentCulture.ToString();
            string cultureUI = Thread.CurrentThread.CurrentUICulture.ToString();
            culture = id + culture.Substring(2);
            cultureUI = id + cultureUI.Substring(2);

            if (culture.Length != 5) culture = cultureUI = id;

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return LocalRedirect(returnUrl);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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