using Microsoft.AspNetCore.Mvc;
using Prototype.Models;
using System.Diagnostics;

namespace Prototype.Controllers
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

        public IActionResult Claims()
        {
            return View(); // Simply return the Claims view
        }

        public IActionResult CreateEditExpense(int? id)
        {
            return View(); // Return the form view (without any database interaction)
        }

        public IActionResult DeleteExpense(int id)
        {
            // Just redirect back to the Claims view
            return RedirectToAction("Claims");
        }

        public IActionResult CreateForm(Claims model)
        {
            // Redirect back to the Claims list without any database operations
            return RedirectToAction("Claims");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SubmitClaim(string lectureName, string lectureSurname, string employeeNo, string contactDetails, string claimPeriod, string description)
        {
            // Process the form data (e.g., save to database)

            // Return a view or a success message
            ViewBag.Message = "Successfully submitted!";
            return View();
        }
    }
}

