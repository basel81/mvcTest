using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Offer
    {
        public int OfferId { get; set; }
        public string OfferTitle { get; set; }
        public string OfferText { get; set; }
        public DateTime OfferDate { get; set; }
        public DateTime ActivationDate { get; set; }
        public int ShopId { get; set; }
        public string Photo { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Shoptype Shop { get; set; }
    }
}
