using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvertGroup.Models.Clients
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int ClientCode { get; set; }

        [Display(Name = "Фамилия и имя клиента")]
        public string Name { get; set; }

        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        public int CategoryId { get; set; }
    }
}