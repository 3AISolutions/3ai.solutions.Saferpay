namespace _3ai.solutions.Saferpay.Models
{
    public class Refund
    {
        public Amount Amount { get; set; }
        public string OrderId { get; set; }
        public string Description { get; set; }
        public bool RestrictRefundAmountToCapturedAmount { get; set; }
    }
}
