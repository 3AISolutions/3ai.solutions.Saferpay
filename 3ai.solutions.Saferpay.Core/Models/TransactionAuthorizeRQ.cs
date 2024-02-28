namespace _3ai.solutions.Saferpay.Models
{
    public class TransactionAuthorizeRQ : BaseRequest
    {
        public string Token { get; set; }
        public string VerificationCode { get; set; }
    }
}
