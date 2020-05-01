using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Datacollector
    {
        public Datacollector()
        {
            Datacollectorshop = new HashSet<Datacollectorshop>();
            Dcpayment = new HashSet<Dcpayment>();
        }

        public int Dcid { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int IsActive { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Zone { get; set; }
        public string Address { get; set; }
        public string Macaddress { get; set; }
        public DateTime AddinfDate { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Datacollectorshop> Datacollectorshop { get; set; }
        public virtual ICollection<Dcpayment> Dcpayment { get; set; }
    }
}
