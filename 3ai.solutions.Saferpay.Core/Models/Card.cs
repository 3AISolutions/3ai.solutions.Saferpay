namespace _3ai.solutions.Saferpay.Models
{
    public class Card
    {
        public string MaskedNumber { get; set; }
        public int ExpYear { get; set; }
        public int ExpMonth { get; set; }
        public string HolderName { get; set; }
        public string CountryCode { get; set; }
    }
}
