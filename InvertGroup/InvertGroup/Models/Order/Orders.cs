using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvertGroup.Models.Order
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [Display(Name = "Код товара")]
        public int OrderCode { get; set; }

        [Display(Name = "Код клиента")]
        public int ClientCode { get; set; }

        [Display(Name = "Дата заказа")]
        public Nullable<DateTime> OrederDate { get; set; }
    }
}