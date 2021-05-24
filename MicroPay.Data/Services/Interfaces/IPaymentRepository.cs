using MicroPay.Data.Dtos;
using MicroPay.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroPay.Data.Services.Interfaces
{
    public interface IPaymentRepository
    {
        Task<PaymentResponse> ProcessPayment(PaymentDto payment);
        Task<PaymentDto> QueryPayment(string paymentReference);
    }
}
