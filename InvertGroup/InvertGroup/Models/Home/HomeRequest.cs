using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvertGroup.Models.Home
{
    public class HomeRequest
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия и имя клиента")]
        public string Name { get; set; }

        [Display(Name = "Адрес")]
        public string Adress { get; set; }

        [Display(Name = "Общая сумма по заказам")]
        public double TotalAmountByOrders { get; set; }
    }
}