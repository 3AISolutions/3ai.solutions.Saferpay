namespace _3ai.solutions.Saferpay.Models
{
    public class RequestHeader
    {
        public string SpecVersion { get; set; }
        public string CustomerId { get; set; }
        public string RequestId { get; set; }
        public int RetryIndicator { get; set; } = 0;
    }
}
