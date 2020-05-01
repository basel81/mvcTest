using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcTest.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { set; get; }
    }
}
