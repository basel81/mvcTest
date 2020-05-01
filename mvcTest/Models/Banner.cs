using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Banner
    {
        public int BannerId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public string Photo { get; set; }
        public string Link { get; set; }

        public virtual Client Client { get; set; }
    }
}
