using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _3ai.solutions.Saferpay.Models
{
    public class Payer
    {
        [JsonConverter(typeof(StringEnumConverter))] public LanguageCode LanguageCode { get; set; }
        public string IpAddress { get; set; }
        public string Ipv6Address { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address BillingAddress { get; set; }
    }
}
