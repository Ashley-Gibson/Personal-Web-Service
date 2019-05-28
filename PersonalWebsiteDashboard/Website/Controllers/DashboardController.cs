using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Website.Models;
using PersonalWebsiteDashboard;

namespace Website.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            WebServiceManager webServiceManager = new WebServiceManager();

            // Send Formatted Blog HTML to Frontend
            ViewData["VisualStudioBlogHtml"] = webServiceManager.Blog_GetRequest("https://devblogs.microsoft.com/visualstudio/feed/", "VisualStudio");
            ViewData["GoogleDevsBlogHtml"] = webServiceManager.Blog_GetRequest("http://feeds.feedburner.com/GDBcode", "GoogleDevelopers");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
