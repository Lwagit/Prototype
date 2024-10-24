namespace Prototype.Models
{
    public class ClaimReviewModel
    {
        //public int Id { get; set; } // Add this property
        public int Hours { get; set; }
        public string Programme { get; set; }
        public string ModuleCode { get; set; }
        public string Groups { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
