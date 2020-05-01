using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Client
    {
        public Client()
        {
            Banner = new HashSet<Banner>();
            ClientPayment = new HashSet<ClientPayment>();
            Joboffer = new HashSet<Joboffer>();
            Jobrequest = new HashSet<Jobrequest>();
            Logs = new HashSet<Logs>();
            Offer = new HashSet<Offer>();
            Saleoffer = new HashSet<Saleoffer>();
        }

        public int ClientId { get; set; }
        public string RealName { get; set; }
        public DateTime RegisterationDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Macaddress { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Banner> Banner { get; set; }
        public virtual ICollection<ClientPayment> ClientPayment { get; set; }
        public virtual ICollection<Joboffer> Joboffer { get; set; }
        public virtual ICollection<Jobrequest> Jobrequest { get; set; }
        public virtual ICollection<Logs> Logs { get; set; }
        public virtual ICollection<Offer> Offer { get; set; }
        public virtual ICollection<Saleoffer> Saleoffer { get; set; }
    }
}
