namespace Do_An.Models.Momo
{
    public class MomoCreatePaymentResponseModel
    {
        public string RequestId { get; set; }

        public string ErrorCode { get; set; }

        public string OrderId { get; set; }

        public string Message { get; set; }

        public string LocalMessage { get; set; }

        public string RequestType { get; set; }

        public string PayUrl { get; set; }

        public string Signature { get; set; }

        public string QrCodeUrl {  get; set; }

        public string DeepLink { get; set; }

        public string DeeplinkWenInApp { get; set; }
    }
}
