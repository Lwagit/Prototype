using Microsoft.AspNetCore.Mvc;
using Prototype.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string connectionString = "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=prototype;Integrated Security=True;Persist Security Info=True;Trust Server Certificate=True";
        //private readonly ApplicationDbContext _context;

        public HomeController( ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
               // var claims = _context.Claims.ToList(); // Fetch claims from the database
               return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching claims: {ex.Message}");
                return StatusCode(500, "Internal server error while fetching claims.");
            }
        }

        public IActionResult SubmitClaim()
        {
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult UpdateInfo()
        {
            // Logic to update lecturer information
            return View();
        }

       

        public IActionResult GenerateReports()
        {
            // Pass data to the view if needed, or just return data.
            return View();
        }

        public IActionResult HrView()
        {
            return View();
        }

       

        public IActionResult SignUp()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ClaimReview()
        {
            return View(); // Return claim result view
        }

        public IActionResult Claims()
        {
            try
            {
               // var claims = _context.Claims.ToList(); // Fetch claims from database
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching claims: {ex.Message}");
                return StatusCode(500, "Internal server error while fetching claims.");
            }
        }

        public IActionResult CreateEditExpense(int id)
        {
            return View(); // Return the form view (without any database interaction)
        }

        public IActionResult DeleteExpense(int id)
        {
            try
            {
                // Perform necessary deletion logic here (if applicable)
                return RedirectToAction("Claims");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting expense: {ex.Message}");
                return StatusCode(500, "Internal server error while deleting expense.");
            }
        }

        [HttpPost]
        public IActionResult EditExpense()
        {
            try
            {
                // Perform update logic here (if applicable)
                return RedirectToAction("Claims");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error editing expense: {ex.Message}");
                return StatusCode(500, "Internal server error while editing expense.");
            }
        }

        public IActionResult ApprovedExpense(int id)
        {
            return RedirectToAction("Claims");
        }

        public IActionResult RejectedExpense(int id)
        {
            return RedirectToAction("Claims");
        }

        public IActionResult ClaimResult()
        {
            return View();
        }

        public IActionResult CreateForm(Claims model)
        {
            // Redirect back to the Claims list without any database operations
            return RedirectToAction("Claims");
        }
    }

    // Assuming this is part of your Models (simplified for clarity)
    public class Claims
    {
        public decimal Hours { get; set; }
        public string SelectedCourse { get; set; }
        public string moduleCode { get; set; }
        public string Groups { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }

        // claim method matching the parameters passed in the controller
        public string claim(decimal hours, string programme, string moduleCode, string groups, decimal hourlyRate, decimal totalAmount, string description, string filename)
        {
            // Here you would save the claim details to the database or perform other necessary operations.
            // Simulating success message for now:
            return "done";
        }

        public class SelectListItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            [NotMapped]
            public SelectListGroup Group { get; set; } // Ignore this property
        }
    }
}
