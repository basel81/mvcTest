using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Jobrequest
    {
        public int JobRequestId { get; set; }
        public int ClientId { get; set; }
        public string RequestTitle { get; set; }
        public string RequestText { get; set; }
        public DateTime RequestDate { get; set; }
        public int Days { get; set; }
        public int Cost { get; set; }

        public virtual Client Client { get; set; }
    }
}
