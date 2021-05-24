using AutoMapper;
using MicroPay.Data.Dtos;
using MicroPay.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroPay.Data.Configurations
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Response, ResponseDto>().ReverseMap();
        }
    }
}
