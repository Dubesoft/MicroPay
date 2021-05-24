using MicroPay.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroPay.Data.Services.Interfaces
{
    public interface IPay
    {
        Task<PaymentResponse> PayAsync(PaymentDto payment);
    }
}
