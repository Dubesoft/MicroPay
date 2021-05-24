using GeneralPurposeComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroPay.Data.Dtos
{
    public class PaymentDto
    {
        [Required(ErrorMessage = "Amount is required")]
        [Range(0, 99999.99)]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Select your preferred currency")]
        [StringLength(3)]
        public string Currency { get; set; }
        [Required(ErrorMessage = "Card Number is required")]
        [MaxLength(16)]
        [MinLength(16)]
        [RegularExpression("[^0-9]", ErrorMessage = "Card Number must be numeric")]
        public int CardNumber { get; set; }
        [Required(ErrorMessage = "CVV is required")]
        [MaxLength(3)]
        [MinLength(3)]
        [RegularExpression("[^0-9]", ErrorMessage = "CVVmust be numeric")]
        public int CVV { get; set; }
        [Required(ErrorMessage = "Expiry Date is required")]
        [DateLessThanOrEqualToToday]
        public DateTime ExpiryDate { get; set; }
        [Required(ErrorMessage = "User Id is required")]
        public string UserId { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }
    }
}
