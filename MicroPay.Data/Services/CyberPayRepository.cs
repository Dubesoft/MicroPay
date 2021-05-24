using GeneralPurposeComponent;
using MicroPay.Data.Dtos;
using MicroPay.Data.Models;
using MicroPay.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroPay.Data.Services
{
    public class CyberPayRepository : IPay
    {
        public Task<PaymentResponse> PayAsync(PaymentDto payment)
        {
            var paymentResult = new PaymentResponse();



            var cyberPay = new Payment()
            {
                PaymentReference = Guid.NewGuid().ToString(),
                Amount = payment.Amount,
                Currency = payment.Currency,
                CardNumber = payment.CardNumber,
                CVV = payment.CVV,
                ExpiryDate = payment.ExpiryDate,
                UserId = payment.UserId,
                TimeStamp = DateTime.UtcNow
            };

            //Feed to a real CyberPay payment gateway
            //var result = await CyberPay(cyberPay);

            if (StatusCode.Success == 0)
            {
                paymentResult.StatusCode = StatusCode.Success;
                paymentResult.Message = Message.Success;
                paymentResult.PaymentPlatform = "CyberPay Payment Gateway";
            }
            else if (StatusCode.Success == 1)
            {
                paymentResult.StatusCode = StatusCode.Pending;
                paymentResult.Message = Message.Pending;
                paymentResult.PaymentPlatform = "CyberPay Payment Gateway";
            }
            else
            {
                paymentResult.StatusCode = StatusCode.Failed;
                paymentResult.Message = Message.Failed;
                paymentResult.PaymentPlatform = "CyberPay Payment Gateway";
            }

            return paymentResult;
        }
    }
}
