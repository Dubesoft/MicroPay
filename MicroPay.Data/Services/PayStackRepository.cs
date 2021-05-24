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
    public class PayStackRepository : IPay
    {
        public Task<PaymentResponse> PayAsync(PaymentDto payment)
        {
            var paymentResult = new PaymentResponse();



            var payStackPay = new Payment()
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

            //Feed to a real PayStack payment gateway
            //var result = await PayStack(payStackPay);

            if (StatusCode.Success == 0)
            {
                paymentResult.StatusCode = StatusCode.Success;
                paymentResult.Message = Message.Success;
                paymentResult.PaymentPlatform = "PayStack Payment Gateway";
            }
            else if (StatusCode.Success == 1)
            {
                paymentResult.StatusCode = StatusCode.Pending;
                paymentResult.Message = Message.Pending;
                paymentResult.PaymentPlatform = "PayStack Payment Gateway";
            }
            else
            {
                paymentResult.StatusCode = StatusCode.Failed;
                paymentResult.Message = Message.Failed;
                paymentResult.PaymentPlatform = "PayStack Payment Gateway";
            }

            return paymentResult;
        }
    }
}
