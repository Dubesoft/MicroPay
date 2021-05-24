using System;
using System.Collections.Generic;
using System.Text;

namespace MicroPay.Data.Dtos
{
    public class PaymentResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string PaymentPlatform { get; set; }
    }
}
