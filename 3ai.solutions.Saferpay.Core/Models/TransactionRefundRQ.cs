namespace _3ai.solutions.Saferpay.Models
{
    public class TransactionRefundRQ : BaseRequest
    {
        public Refund Refund { get; set; }
        public CaptureReference CaptureReference { get; set; }
    }
}
