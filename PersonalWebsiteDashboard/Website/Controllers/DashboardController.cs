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

            // Get Database Courses and Certs Data
            ViewData["CertificationOneData"] = webServiceManager.GetPersonalDashboardCertificationData()[0];
            ViewData["CertificationOneTitle"] = webServiceManager.GetPersonalDashboardCertificationDataCourseTitles()[0];
            ViewData["CertificationTwoData"] = webServiceManager.GetPersonalDashboardCertificationData()[0];
            ViewData["CertificationTwoTitle"] = webServiceManager.GetPersonalDashboardCertificationDataCourseTitles()[0];
            ViewData["CertificationThreeData"] = webServiceManager.GetPersonalDashboardCertificationData()[0];
            ViewData["CertificationThreeTitle"] = webServiceManager.GetPersonalDashboardCertificationDataCourseTitles()[0];

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
