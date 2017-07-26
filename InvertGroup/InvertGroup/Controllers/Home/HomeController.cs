using InvertGroup.Models;
using InvertGroup.Models.Home;
using InvertGroup.Models.Order;
using InvertGroup.Models.OrderStrings;
using InvertGroup.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InvertGroup.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GetAllClients()
        {
            List<HomeRequest> clientListRequest = new List<HomeRequest>(); 
            using (var dbContext = new ShopContext())
            {
                
                var clientsList = dbContext.ClientTable.ToList();
                var ordersList = dbContext.Orders.ToList();
                var orderStringList = dbContext.OrderStringTable.ToList();

                List<OrderString> orderStringListSorted = new List<OrderString>();

                double totalAmount;

                foreach (var client in clientsList)
                {
                    List<Orders> ordersByClietn = new List<Orders>();

                    ordersByClietn.AddRange(ordersList.Where(u => u.ClientCode == client.ClientCode).ToList());
                    totalAmount = 0;

                    foreach (var order in ordersByClietn)
                    {
                        orderStringListSorted = orderStringList.Where(u => u.OrderCode == order.OrderCode).ToList();
                        totalAmount += orderStringListSorted.Sum(u=>u.TotalAmount);
                    }

                    clientListRequest.Add(new HomeRequest()
                    {
                        Id = client.ClientCode,
                        Name = client.Name,
                        Adress = client.Adress,
                        TotalAmountByOrders = totalAmount
                    });
                }
            }
            var jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(clientListRequest);
        }
    }
}