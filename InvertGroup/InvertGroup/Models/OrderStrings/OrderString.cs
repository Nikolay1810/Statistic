using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvertGroup.Models.OrderStrings
{
    [Table("OrderString")]
    public class OrderString
    {
        [Key]
        public int StringCode { get; set; }

        public int OrderCode { get; set; }

        public int ProductCode { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double TotalAmount { get; set; }
    }
}