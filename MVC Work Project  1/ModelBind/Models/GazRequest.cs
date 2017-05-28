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
        [RegularExpression("^[A-Z]{4-4}[0-9]{4-4}$")]
        public int RequestNo { get; set; }

        [StringLength(7)]
        public string OldName { get; set; }

        [Required]
        public string NewName { get; set; }

        public string DOB { get; set; }


        public string City { get; set; }
    }
}