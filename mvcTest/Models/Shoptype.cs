using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvcTest.Models
{
    public partial class Shoptype
    {
        public Shoptype()
        {
            Offer = new HashSet<Offer>();
            Shop = new HashSet<Shop>();
        }

        public int ShopTypeId { get; set; }
        [Display(Name = "الاسم بالعربي")]
        public string Aname { get; set; }
        public string Ename { get; set; }
        public string Aliases { get; set; }
        public string Ealiases { get; set; }
        public string Photo { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Offer> Offer { get; set; }
        public virtual ICollection<Shop> Shop { get; set; }
    }
}
