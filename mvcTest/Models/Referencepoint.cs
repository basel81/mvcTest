using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Referencepoint
    {
        public Referencepoint()
        {
            Shop = new HashSet<Shop>();
        }

        public int ReferencePointId { get; set; }
        public string AName { get; set; }
        public string Location { get; set; }
        public string EName { get; set; }

        public virtual ICollection<Shop> Shop { get; set; }
    }
}
