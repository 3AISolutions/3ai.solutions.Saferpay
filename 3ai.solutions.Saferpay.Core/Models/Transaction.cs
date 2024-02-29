using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _3ai.solutions.Saferpay.Models
{
    public class Transaction
    {
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))] public TransactionStatus Status { get; set; }
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public Amount Amount { get; set; }
        public string AcquirerName { get; set; }
        public string AcquirerReference { get; set; }
        public string SixTransactionReference { get; set; }
        public string ApprovalCode { get; set; }
    }
}
