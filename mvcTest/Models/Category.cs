using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Category
    {
        public Category()
        {
            Itemstosale = new HashSet<Itemstosale>();
            Shoptype = new HashSet<Shoptype>();
        }

        public int CategorId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryEname { get; set; }
        public string CategoryPhoto { get; set; }

        public virtual ICollection<Itemstosale> Itemstosale { get; set; }
        public virtual ICollection<Shoptype> Shoptype { get; set; }
    }
}
