using MicroPay.Api.Controllers;
using MicroPay.Data.Dtos;
using MicroPay.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroPay.UnitTest
{
    [TestClass]
    public class PaymentControllerTest
    {
        //evans.okosodo@gmail.com
        //username: DavidEhigiator
        //blevando

        [TestMethod]
        public void Check_If_ProcessPayment_Returns_Null(PaymentDto pay)
        {
            //Arrange
            


            var payment = new PaymentController();
            //Act
            var result = payment.ProcessPayment(pay);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Check_If_ProcessPayment_Returns_PaymentResponse(PaymentDto pay)
        {
            //Arrange

            var paymentResponse = new PaymentResponse();

            var payment = new PaymentController();
            //Act
            var result = payment.ProcessPayment(pay);

            //Assert
            Assert.AreEqual(paymentResponse, result);
        }

        [TestMethod]
        public void Check_If_OueryPayment_Method_Returns_Null(string payRefernce)
        {
            //Arrange

            var payment = new PaymentController();
            //Act
            var result = payment.QueryPayment(payRefernce);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Check_If_OueryPayment_Method_Fetches_Payment(string payRefernce)
        {
            //Arrange

            var data = new PaymentDto();
            var paymentResponse = new PaymentResponse();

            var payment = new PaymentController();
            //Act
            var result = payment.QueryPayment(payRefernce);

            //Assert
            Assert.AreEqual(paymentResponse, data);
        }



    }
}
