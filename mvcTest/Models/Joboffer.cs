using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Joboffer
    {
        public int JobOfferId { get; set; }
        public int ClientId { get; set; }
        public string OfferText { get; set; }
        public string OfferTitle { get; set; }
        public DateTime OfferDate { get; set; }
        public int Days { get; set; }
        public int Cost { get; set; }

        public virtual Client Client { get; set; }
    }
}
