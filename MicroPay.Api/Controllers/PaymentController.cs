using MicroPay.Data.Dtos;
using MicroPay.Data.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public readonly IPaymentRepository _paymentRepository;
        private readonly ILogger _logger;

        public PaymentController()
        {
        }

        public PaymentController(IPaymentRepository paymentRepository,
                                 ILogger logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        //Note the 3 error is as a result the payment platform.
        //When you feed in a real payment platfrom, it goes away.
        //It return a response from the payment gateway.

        [HttpPost]
        public async Task<ActionResult<PaymentResponse>> ProcessPayment(PaymentDto pay)
        {
            
            try
            {
                if (pay == null)
                {
                    return BadRequest();
                }

                var result = await _paymentRepository.ProcessPayment(pay);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing paymeny{ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

            [HttpGet("{payRefernce}")]
            public async Task<ActionResult<PaymentDto>> QueryPayment(string payRefernce)
            {
                try
                {
                    var result = await _paymentRepository.QueryPayment(payRefernce);
                    if (result == null)
                    {
                        return NotFound(result);
                    }
                    return result;
                }
                catch (Exception ex)
                {
                _logger.LogError($"Error fetching paymeny reference{ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
                }
            }
        

    }
}
