using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using _3ai.solutions.Saferpay.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _3ai.solutions.Saferpay
{
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_baseUri + uri);
            httpWebRequest.KeepAlive = false;
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add(_authHeader.Key, _authHeader.Value);
            //httpWebRequest.Headers.Add("Accept", "application/json");
            httpWebRequest.Accept = "application/json";

            if (request.RequestHeader == null)
                request.RequestHeader = new RequestHeader();
            request.RequestHeader.SpecVersion = "1.38";
            if (string.IsNullOrEmpty(request.RequestHeader.CustomerId))
                request.RequestHeader.CustomerId = _customerId;
            if (string.IsNullOrEmpty(request.RequestHeader.RequestId))
                request.RequestHeader.RequestId = Guid.NewGuid().ToString();

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(request, new StringEnumConverter());
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpResponse.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Saferpay API returned status code {httpResponse.StatusCode} {httpResponse.StatusDescription}");

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Tout>(result);
            }
        }
    }
}
