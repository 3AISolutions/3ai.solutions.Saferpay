namespace _3ai.solutions.Saferpay.Models
{
    public class TransactionRefundRS : BaseResponse
    {
        public Transaction Transaction { get; set; }
        public PaymentMeans PaymentMeans { get; set; }
    }
}
