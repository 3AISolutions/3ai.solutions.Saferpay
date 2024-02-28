namespace _3ai.solutions.Saferpay.Models
{
    public class PaymentPageAssertRS : BaseResponse
    {
        public Transaction Transaction { get; set; }
        public PaymentMeans PaymentMeans { get; set; }
        public Liability Liability { get; set; }
    }
}
