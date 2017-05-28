using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project_1.Models
{
    public class GazRequest
    {
        [Key]
        public int RequestNo { get; set; }

        public string OldName { get; set; }

        public string NewName { get; set; }

        public string DOB { get; set; }

        public string City { get; set; }
    }
}