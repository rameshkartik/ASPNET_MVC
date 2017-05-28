using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project_1.Models
{
    public class LoginCredential
    {
        [Key]
        public string UserName { get; set; }

        public string Passwrd { get; set; }
    }
}