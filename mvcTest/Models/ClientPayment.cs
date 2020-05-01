using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class ClientPayment
    {
        public int? ClientId { get; set; }
        public int PaymentId { get; set; }
        public int Amount { get; set; }
        public string Reciept { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Reason { get; set; }

        public virtual Client Client { get; set; }
    }
}
