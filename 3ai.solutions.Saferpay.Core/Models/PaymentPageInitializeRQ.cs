namespace _3ai.solutions.Saferpay.Models
{
    public class PaymentPageInitializeRQ : BaseRequest
    {
        public string TerminalId { get; set; }
        public Payment Payment { get; set; }
        public ReturnUrl ReturnUrl { get; set; }
        public Payer Payer { get; set; }
        public Styling Styling { get; set; }
    }
}
