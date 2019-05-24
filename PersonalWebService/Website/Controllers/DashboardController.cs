using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Website.Models;
using PersonalWebService;

namespace Website.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            WebServiceManager webServiceManager = new WebServiceManager();

            ViewData["VisualStudioBlogHtml"] = webServiceManager.VSBlog_GetRequest();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
