using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvertGroup.Models.OrdersByClient
{
    public class DetailOrderString
    {
        public int ProductCode { get; set; }

        [Display(Name = "Товар")]
        public string ProductName { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Общая цена")]
        public double TotalAmount { get; set; }
    }
}