using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Shop
    {
        public Shop()
        {
            Activationtable = new HashSet<Activationtable>();
            Datacollectorshop = new HashSet<Datacollectorshop>();
            Shopitem = new HashSet<Shopitem>();
        }

        public int ShopId { get; set; }
        public int ShopTypeId { get; set; }
        public string ShopName { get; set; }
        public string EshopName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Properties { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Facebook { get; set; }
        public string Twiter { get; set; }
        public string Website { get; set; }
        public DateTime RegisterationDate { get; set; }
        public DateTime ActivationDate { get; set; }
        public int ReferencePointId { get; set; }
        public string Notes { get; set; }

        public virtual Referencepoint ReferencePoint { get; set; }
        public virtual Shoptype ShopType { get; set; }
        public virtual ICollection<Activationtable> Activationtable { get; set; }
        public virtual ICollection<Datacollectorshop> Datacollectorshop { get; set; }
        public virtual ICollection<Shopitem> Shopitem { get; set; }
    }
}
