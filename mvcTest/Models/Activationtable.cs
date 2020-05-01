using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Activationtable
    {
        public int ActivationId { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
