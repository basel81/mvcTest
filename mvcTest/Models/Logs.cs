using System;
using System.Collections.Generic;

namespace mvcTest.Models
{
    public partial class Logs
    {
        public int LogsId { get; set; }
        public int ClientId { get; set; }
        public DateTime LogDate { get; set; }
        public string MacAddress { get; set; }
        public string Location { get; set; }

        public virtual Client Client { get; set; }
    }
}
