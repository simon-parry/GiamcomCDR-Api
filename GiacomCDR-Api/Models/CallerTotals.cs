namespace GiacomCDR_Api.Models
{
    public class CallerTotals
    {
        public string CallerId { get; set; } = string.Empty;
        public decimal TotalCost { get; set; }
        public double AverageDuration { get; set; } 
        public decimal AverageCost { get; set; }
    }
}
