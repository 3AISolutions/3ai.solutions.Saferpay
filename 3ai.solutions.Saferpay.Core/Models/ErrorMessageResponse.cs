namespace _3ai.solutions.Saferpay.Models
{
    public class ErrorMessageResponse
    {
        public string Behavior { get; set; }
        public string[] ErrorDetail { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorName { get; set; }
        public string OrderId { get; set; }
        public string PayerMessage { get; set; }
        public string ProcessorMessage { get; set; }
        public string ProcessorName { get; set; }
        public string ProcessorResult { get; set; }
        public ResponseHeader ResponseHeader { get; set; }
        public Risk Risk { get; set; }
        public string TransactionId { get; set; }
    }
}
