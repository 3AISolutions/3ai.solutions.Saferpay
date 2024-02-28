namespace _3ai.solutions.Saferpay.Models
{
    public class PaymentPageAssertRS
    {
        public RequestHeader RequestHeader { get; set; }
        public Transaction Transaction { get; set; }
        public PaymentMeans PaymentMeans { get; set; }
        public Liability Liability { get; set; }
    }
}
