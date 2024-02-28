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

    public class TransactionInitializeRQ : PaymentPageInitializeRQ { }

    public class Redirect
    {
        public string RedirectUrl { get; set; }
        public bool PaymentMeansRequired { get; set; }
    }

    public class ResponseHeader
    {
        public string SpecVersion { get; set; }
        public string RequestId { get; set; }
    }

    public class TransactionInitializeRS
    {
        public ResponseHeader ResponseHeader { get; set; }
        public string Token { get; set; }
        public System.DateTime Expiration { get; set; }
        public bool LiabilityShift { get; set; }
        public bool RedirectRequired { get; set; }
        public Redirect Redirect { get; set; }
    }

    public class TransactionAuthorizeRQ : BaseRequest
    {
        public string Token { get; set; }
        public string VerificationCode { get; set; }
    }

    public class TransactionAuthorizeRS : PaymentPageAssertRS { }
    
    public class Payer
    {
        public string LanguageCode { get; set; }
    }

    public class Styling
    {
        public string CssUrl { get; set; }
    }
}
