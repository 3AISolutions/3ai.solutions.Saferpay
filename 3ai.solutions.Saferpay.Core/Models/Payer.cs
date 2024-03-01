namespace _3ai.solutions.Saferpay.Models
{
    public class Payer
    {
        public LanguageCode LanguageCode { get; set; }
        public string IpAddress { get; set; }
        public string Ipv6Address { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address BillingAddress { get; set; }
    }
}
