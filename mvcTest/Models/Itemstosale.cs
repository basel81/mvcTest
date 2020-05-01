using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Itemstosale
    {
        public Itemstosale()
        {
            Shopitem = new HashSet<Shopitem>();
        }

        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string Aname { get; set; }
        public string Ename { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Shopitem> Shopitem { get; set; }
    }
}
