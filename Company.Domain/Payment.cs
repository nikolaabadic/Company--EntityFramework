using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Domain
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfPayment { get; set; }
    }
}
