namespace _3ai.solutions.Saferpay.Models
{
    public class PaymentPageInitializeRQ : BaseRequest
    {
        public string TerminalId { get; set; }
        public Payment Payment { get; set; }
        public ReturnUrl ReturnUrl { get; set; }
    }
}
