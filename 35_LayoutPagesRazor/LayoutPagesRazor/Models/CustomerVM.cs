using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LayoutPagesRazor.Models;

namespace LayoutPagesRazor.ViewModel
{
    public class CustomerVM:LayoutVM
    {
        public Customer CusObj { get; set; }

        public List<Customer> Customers { get; set; }

    }
}