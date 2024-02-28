namespace _3ai.solutions.Saferpay.Models
{
    public class TransactionInitializeRS : BaseResponse
    {
        public string Token { get; set; }
        public System.DateTime Expiration { get; set; }
        public bool LiabilityShift { get; set; }
        public bool RedirectRequired { get; set; }
        public Redirect Redirect { get; set; }
    }
}
