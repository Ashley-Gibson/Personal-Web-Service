using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Website.Models;
using PersonalWebsiteDashboard;
using System.Collections.Generic;

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

            // Get Database Courses and Certs Data
            List<string> certificationData = webServiceManager.GetPersonalDashboardCertificationData();

            for (int i = 1; i <= certificationData.Count; i++)
            {
                ViewData["Certification" + i + "Data"] = webServiceManager.GetPersonalDashboardCertificationData()[i-1];
                ViewData["Certification" + i + "Title"] = webServiceManager.GetPersonalDashboardCertificationDataCourseTitles()[i-1];
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
