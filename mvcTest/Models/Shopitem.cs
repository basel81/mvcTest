using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Shopitem
    {
        public int ShopItemId { get; set; }
        public int ItemId { get; set; }
        public int ShopId { get; set; }

        public virtual Itemstosale Item { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
