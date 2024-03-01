namespace _3ai.solutions.Saferpay.Models
{
    public class TransactionCaptureRS : BaseResponse
    {
        public string CaptureId { get; set; }
        public TransactionStatus Status { get; set; }
        public string Date { get; set; }
        public object Invoice { get; set; }
    }
}
