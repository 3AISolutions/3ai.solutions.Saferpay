using System;
using System.Collections.Generic;
using System.Net;
using _3ai.solutions.Saferpay.Models;

namespace _3ai.solutions.Saferpay
{
    public class NoKeepAliveWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request != null)
            {
                request.KeepAlive = false;
            }
            return request;
        }
    }

    public class SaferpayService
    {
        private readonly string _baseUri;
        private readonly KeyValuePair<string, string> _authHeader;
        private readonly string _customerId;
        private readonly string _terminalId;

        public SaferpayService(SaferpayConfig saferpayConfig)
        {
            _baseUri = saferpayConfig.BaseUrl;
            _customerId = saferpayConfig.CustomerId;
            _terminalId = saferpayConfig.TerminalId;
            _authHeader = new KeyValuePair<string, string>("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{saferpayConfig.Username}:{saferpayConfig.Password}")));
        }

        public PaymentPageInitializeRS PaymentPageInitialize(PaymentPageInitializeRQ request)
        {
            if (string.IsNullOrEmpty(request.TerminalId))
                request.TerminalId = _terminalId;
            return Invoke<PaymentPageInitializeRS, PaymentPageInitializeRQ>("Payment/v1/PaymentPage/Initialize", request);
        }

        public PaymentPageAssertRS PaymentPageAssert(PaymentPageAssertRQ request)
        {
            return Invoke<PaymentPageAssertRS, PaymentPageAssertRQ>("Payment/v1/PaymentPage/Assert", request);
        }

        public TransactionCaptureRS TransactionCapture(TransactionCaptureRQ request)
        {
            return Invoke<TransactionCaptureRS, TransactionCaptureRQ>("Payment/v1/Transaction/Capture", request);
        }

        public TransactionCancelRS TransactionCancel(TransactionCancelRQ request)
        {
            return Invoke<TransactionCancelRS, TransactionCancelRQ>("Payment/v1/Transaction/Cancel", request);
        }

        public TransactionRefundRS TransactionRefund(TransactionRefundRQ request)
        {
            return Invoke<TransactionRefundRS, TransactionRefundRQ>("Payment/v1/Transaction/Refund", request);
        }

        public TransactionInquireRS TransactionInquire(TransactionInquireRQ request)
        {
            return Invoke<TransactionInquireRS, TransactionInquireRQ>("Payment/v1/Transaction/Inquire", request);
        }

        private Tout Invoke<Tout, Tin>(string uri, Tin request) where Tin : BaseRequest
        {
            using (var webClient = new NoKeepAliveWebClient
            {
                BaseAddress = _baseUri,
                Encoding = System.Text.Encoding.UTF8
            })
            {
                webClient.Headers.Add(_authHeader.Key, _authHeader.Value);
                webClient.Headers.Add("Content-Type", "application/json; charset=utf-8");
                webClient.Headers.Add("Accept", "application/json");

                if (request.RequestHeader == null)
                    request.RequestHeader = new RequestHeader();
                request.RequestHeader.SpecVersion = "1.38";
                if (string.IsNullOrEmpty(request.RequestHeader.CustomerId))
                    request.RequestHeader.CustomerId = _customerId;
                if (string.IsNullOrEmpty(request.RequestHeader.RequestId))
                    request.RequestHeader.RequestId = Guid.NewGuid().ToString();

                string requestRq = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                string responseString = webClient.UploadString(uri, "POST", Newtonsoft.Json.JsonConvert.SerializeObject(request));

                return Newtonsoft.Json.JsonConvert.DeserializeObject<Tout>(responseString);
            }
        }
    }
}
