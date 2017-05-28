using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Project_1.Models;

namespace MVC_Project_1.Models
{
    public class GazRequestVM
    {
        public GazRequest GazObj { get; set; }

        public List<GazRequest> GazRequests { get; set; }

    }
}