using System;
using System.Collections.Generic;
using System.Text;

namespace MicroPay.Data.Models
{
    public class Response
    {
        public DateTime TimeStamp { get; set; }
        public string PaymentReference { get; set; }
        public string Message { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
