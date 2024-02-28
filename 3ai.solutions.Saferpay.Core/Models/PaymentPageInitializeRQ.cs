using System;

namespace _3ai.solutions.Saferpay.Models
{
    public class BaseRequest
    {
        public RequestHeader RequestHeader { get; set; }
    }

    public class PaymentPageInitializeRQ : BaseRequest
    {
        public string TerminalId { get; set; }
        public Payment Payment { get; set; }
        public ReturnUrl ReturnUrl { get; set; }
    }

    public class PaymentPageInitializeRS
    {
        public RequestHeader RequestHeader { get; set; }
        public string Token { get; set; }
        public string Expiration { get; set; }
        public string RedirectUrl { get; set; }
    }

    public class PaymentPageAssertRQ : BaseRequest
    {
        public string Token { get; set; }
    }

    public class PaymentPageAssertRS
    {
        public RequestHeader RequestHeader { get; set; }
        public Transaction Transaction { get; set; }
        public PaymentMeans PaymentMeans { get; set; }
        public Liability Liability { get; set; }
    }

    public class TransactionCaptureRQ : BaseRequest
    {
        public TransactionReference TransactionReference { get; set; }
    }

    public class TransactionCaptureRS
    {
        public RequestHeader RequestHeader { get; set; }
        public string CaptureId { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public object Invoice { get; set; }
    }

    public class TransactionCancelRQ : TransactionCaptureRQ { }
    public class TransactionCancelRS : TransactionCaptureRS { }

    public class TransactionReference
    {
        public string TransactionId { get; set; }
    }

    public class ThreeDs
    {
        public bool Authenticated { get; set; }
        public string Xid { get; set; }
    }

    public class Brand
    {
        public string PaymentMethod { get; set; }
        public string Name { get; set; }
    }

    public class Card
    {
        public string MaskedNumber { get; set; }
        public int ExpYear { get; set; }
        public int ExpMonth { get; set; }
        public string HolderName { get; set; }
        public string CountryCode { get; set; }
    }

    public class Liability
    {
        public bool LiabilityShift { get; set; }
        public string LiableEntity { get; set; }
        public ThreeDs ThreeDs { get; set; }
    }

    public class PaymentMeans
    {
        public Brand Brand { get; set; }
        public string DisplayText { get; set; }
        public Card Card { get; set; }
    }

    public class Transaction
    {
        public string Type { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public Amount Amount { get; set; }
        public string AcquirerName { get; set; }
        public string AcquirerReference { get; set; }
        public string SixTransactionReference { get; set; }
        public string ApprovalCode { get; set; }
    }

    public class Payment
    {
        public Amount Amount { get; set; }
        public string OrderId { get; set; }
        public string Description { get; set; }
    }

    public class Amount
    {
        public string Value { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class ReturnUrl
    {
        public string Url { get; set; }
    }

    public class RequestHeader
    {
        public string SpecVersion { get; set; }
        public string CustomerId { get; set; }
        public string RequestId { get; set; }
        public int RetryIndicator { get; set; } = 0;

    }

    public enum PaymentMethods
    {
        ACCOUNTTOACCOUNT,
        ALIPAY,
        AMEX,
        BANCONTACT,
        BONUS,
        DINERS,
        CARD,
        DIRECTDEBIT,
        EPRZELEWY,
        EPS,
        GIROPAY,
        IDEAL,
        INVOICE,
        JCB,
        KLARNA,
        MAESTRO,
        MASTERCARD,
        MYONE,
        PAYCONIQ,
        PAYDIREKT,
        PAYPAL,
        POSTCARD,
        POSTFINANCE,
        POSTFINANCEPAY,
        SOFORT,
        TWINT,
        UNIONPAY,
        VISA,
        WLCRYPTOPAYMENTS,
    }
}
