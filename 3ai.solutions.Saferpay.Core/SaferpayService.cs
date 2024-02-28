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
        public SaferpayService(SaferpayConfig saferpayConfig)
        {
            _baseUri = saferpayConfig.BaseUrl;
            _authHeader = new KeyValuePair<string, string>("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{saferpayConfig.Username}:{saferpayConfig.Password}")));
        }

        public PaymentPageInitializeRS PaymentPageInitialize(PaymentPageInitializeRQ request)
        {
            return Invoke<PaymentPageInitializeRS>("Payment/v1/PaymentPage/Initialize", request, "POST");
        }

        public PaymentPageAssertRS PaymentPageAssert(PaymentPageAssertRQ request)
        {
            return Invoke<PaymentPageAssertRS>("Payment/v1/PaymentPage/Assert", request, "POST");
        }

        public TransactionCaptureRS TransactionCapture(TransactionCaptureRQ request)
        {
            return Invoke<TransactionCaptureRS>("Payment/v1/Transaction/Capture", request, "POST");
        }

        public TransactionCancelRS TransactionCancel(TransactionCancelRQ request)
        {
            return Invoke<TransactionCancelRS>("Payment/v1/Transaction/Cancel", request, "POST");
        }

        private T Invoke<T>(string uri, object request, string method)
        {
            using (var webClient = new NoKeepAliveWebClient
            {
                BaseAddress = _baseUri,
            })
            {
                webClient.Headers.Add(_authHeader.Key, _authHeader.Value);
                string responseString;
                if (request != null)
                {
                    webClient.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    webClient.Headers.Add("Accept", "application/json");
                    webClient.Encoding = System.Text.Encoding.UTF8;
                    responseString = webClient.UploadString(uri, method, Newtonsoft.Json.JsonConvert.SerializeObject(request));
                }
                else
                {
                    responseString = webClient.DownloadString(uri);
                }
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
            }
        }
    }
}
