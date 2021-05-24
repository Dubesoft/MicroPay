using AutoMapper;
using GeneralPurposeComponent;
using MicroPay.Data.Dtos;
using MicroPay.Data.Models;
using MicroPay.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroPay.Data.Services
{
    public class PaymentRepository : IPaymentRepository
    {
        public readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
       
        public PaymentRepository(AppDbContext appDbContext,
                                 IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        public async Task<PaymentResponse> ProcessPayment(PaymentDto payment)
        {
            var response = new PaymentResponse();
            var data = new Payment
            {
                Amount = payment.Amount,
                Currency = payment.Currency,
                CardNumber = payment.CardNumber,
                CVV = payment.CVV,
                ExpiryDate = payment.ExpiryDate,
                UserId = payment.UserId,
                Description = payment.Description
            };

            switch (data.Amount)
            {
                case decimal value when (value <= 200):
                    var flutterRepository = new FlutterRepository();
                    response = await flutterRepository.PayAsync(payment);
                    break;
                case decimal value when (value <= 500):
                    var payStackRepository = new PayStackRepository();
                    response = await payStackRepository.PayAsync(payment);
                    break;
                case decimal value when (value > 500):
                    var cyberPayRepository = new CyberPayRepository();
                    response = await cyberPayRepository.PayAsync(payment);
                    break;
                default:
                    break;
            }

            
                
            var result = await _appDbContext.AddAsync(data);
            await _appDbContext.SaveChangesAsync();

            return response;
        }


        public async Task<PaymentDto> QueryPayment(string paymentReference)
        {
            var response = new PaymentResponse();
  
            var result = await _appDbContext.Payment.FirstOrDefaultAsync(e => e.PaymentReference == paymentReference);

            var data = _mapper.Map<Payment, PaymentDto>(result);

            if (data == null)
            {
                response.Message = Message.DoesNotExist;
            }

            return data;
        }
    }
}
