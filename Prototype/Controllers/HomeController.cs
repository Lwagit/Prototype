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
        /*

        // Handle form submission (POST)
        [HttpPost]
        public async Task<IActionResult> SubmitClaim(string lectureName, string lectureSurname, string employeeNo, string contactDetails, string claimPeriod, string description, IFormFile supportingDocument)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;

                try
                {
                    // Step 1: Save the uploaded document if it exists
                    if (supportingDocument != null && supportingDocument.Length > 0)
                    {
                        try
                        {
                            string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                            if (!Directory.Exists(uploadDir))
                            {
                                Directory.CreateDirectory(uploadDir);
                            }

                            filePath = Path.Combine(uploadDir, Path.GetFileName(supportingDocument.FileName));
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await supportingDocument.CopyToAsync(stream);
                            }
                        }
                        catch (IOException ioEx)
                        {
                            _logger.LogError($"File save error: {ioEx.Message}");
                            ViewBag.ErrorMessage = "Error saving the supporting document. Please try again.";
                            return View(); // Return to the form view with error message
                        }
                    }

                    // Step 2: Insert data into SQL
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        await connection.OpenAsync(); // Open connection asynchronously
                        _logger.LogInformation($"Inserting Claim: {lectureName}, {lectureSurname}, {employeeNo}, {contactDetails}, {claimPeriod}, {description}, {filePath}");

                        string query = "INSERT INTO Claims (LectureName, LectureSurname, EmployeeNo, ContactDetails, ClaimPeriod, Description, SupportingDocumentPath) " +
                                       "VALUES (@LectureName, @LectureSurname, @EmployeeNo, @ContactDetails, @ClaimPeriod, @Description, @SupportingDocumentPath)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameters to the query
                            command.Parameters.Add("@LectureName", SqlDbType.NVarChar).Value = lectureName;
                            command.Parameters.Add("@LectureSurname", SqlDbType.NVarChar).Value = lectureSurname;
                            command.Parameters.Add("@EmployeeNo", SqlDbType.NVarChar).Value = employeeNo;
                            command.Parameters.Add("@ContactDetails", SqlDbType.NVarChar).Value = contactDetails;
                            command.Parameters.Add("@ClaimPeriod", SqlDbType.NVarChar).Value = claimPeriod;
                            command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                            command.Parameters.Add("@SupportingDocumentPath", SqlDbType.NVarChar).Value = filePath ?? "no file";

                            int result = await command.ExecuteNonQueryAsync();  // Execute the insert query asynchronously

                            if (result > 0)
                            {
                                _logger.LogInformation("Data inserted successfully.");
                                ViewBag.Message = "Claim submitted successfully!";
                                return RedirectToAction("Claims"); // Redirect to Claims view
                            }
                            else
                            {
                                _logger.LogWarning("No rows inserted.");
                                ViewBag.Message = "There was a problem submitting the claim.";
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    _logger.LogError($"SQL Error: {sqlEx.Message}");
                    ViewBag.ErrorMessage = "There was a problem connecting to the database.";
                    return StatusCode(500, "Internal server error while processing claim.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error: {ex.Message}");
                    ViewBag.ErrorMessage = "An unexpected error occurred.";
                    return StatusCode(500, "Internal server error.");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid data submitted. Please check the form and try again.";
            }

            return View(); // Return to the form in case of error
        }/

        */

        public IActionResult Privacy()
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
