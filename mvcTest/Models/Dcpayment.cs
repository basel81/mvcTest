using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Dcpayment
    {
        public int DcpaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Dcid { get; set; }
        public int RecNum { get; set; }
        public int Amount { get; set; }

        public virtual Datacollector Dc { get; set; }
    }
}
