using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcTest.Models
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users =  new List<string>();
        }
        public string Id { set; get; }
        [Required]
        public string RoleName { set; get; }
        public List<string> Users { set; get; }
    }
}
