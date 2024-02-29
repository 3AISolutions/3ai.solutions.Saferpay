using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _3ai.solutions.Saferpay.Models
{
    public class Address
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        [JsonConverter(typeof(StringEnumConverter))] public Gender Gender { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Street2 { get; set; }
        public string Phone { get; set; }
        public string VatNumber { get; set; }
        public string CountrySubdivisionCode { get; set; }
    }
}