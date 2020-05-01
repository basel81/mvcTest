using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Datacollectorshop
    {
        public int Dcsid { get; set; }
        public int Dcid { get; set; }
        public int ShopId { get; set; }
        public string Macaddress { get; set; }
        public string Location { get; set; }
        public DateTime AddingDate { get; set; }

        public virtual Datacollector Dc { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
