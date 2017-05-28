using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ModelBind.Models
{
    public class Login
    {
        [Key]
        public string Username { get; set; }

        public string Password { get; set; }

    }
}