namespace _3ai.solutions.Saferpay.Models
{
    public class BaseResponse
    {
        public ResponseHeader ResponseHeader { get; set; }
        public bool HasError => ErrorMessage != null;
        public ErrorMessageResponse ErrorMessage { get; set; }
    }
}
