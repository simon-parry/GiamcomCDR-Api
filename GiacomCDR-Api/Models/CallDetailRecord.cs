using GiacomCDR_Api.DataAccessLayer;

namespace GiacomCDR_Api.Models
{
    public class CallDetailRecord : IEntity
    {
        public Guid Id { get; set; }
        public string CallerId { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public DateTime CallDate { get; set; }      
        public string EndTime { get; set; } = string.Empty;
        public int Duration { get; set; }   
        public decimal Cost { get; set; }
        public string Reference { get; set; } = string.Empty;  
        public string Currency { get; set; } = string.Empty;
    }
}
