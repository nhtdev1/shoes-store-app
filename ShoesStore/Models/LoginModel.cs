using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoesStore.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please input username")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please input password")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}