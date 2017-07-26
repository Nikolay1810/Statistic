using InvertGroup.Models.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvertGroup.Models.OrdersByClient
{
    public class DetailOrders
    {
        public string OrderDate { get; set; }
        public Orders Order { get; set; }
        public List<DetailOrderString> DetailOrederString { get; set; }


        
    }
}