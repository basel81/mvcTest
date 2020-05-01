using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcTest.Models
{
    public class UserRoleViewModel
    {
        public string UserName { set; get; }
        public string UserId { set; get; }

        public bool IsSelected { set; get; }
    }
}
