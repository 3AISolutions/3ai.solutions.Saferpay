namespace _3ai.solutions.Saferpay.Models
{
    public class PaymentPageInitializeRS
    {
        public RequestHeader RequestHeader { get; set; }
        public string Token { get; set; }
        public string Expiration { get; set; }
        public string RedirectUrl { get; set; }
    }
}
