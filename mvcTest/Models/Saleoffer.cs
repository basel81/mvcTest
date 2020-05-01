using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Saleoffer
    {
        public int Soid { get; set; }
        public int ClientId { get; set; }
        public string OfferText { get; set; }
        public string OfferTitle { get; set; }
        public string Photo { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }

        public virtual Client Client { get; set; }
    }
}
