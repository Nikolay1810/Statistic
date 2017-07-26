using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvertGroup.Models.Products
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}