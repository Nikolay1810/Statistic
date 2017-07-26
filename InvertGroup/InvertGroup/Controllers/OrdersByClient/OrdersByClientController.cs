using InvertGroup.Models.Clients;
using InvertGroup.Models.OrdersByClient;
using InvertGroup.Models.OrderStrings;
using InvertGroup.Models.Products;
using InvertGroup.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InvertGroup.Controllers.OrdersByClient
{
    public class OrdersByClientController : Controller
    {
        // GET: OrdersByClient
        public ActionResult OrdersByClient()
        {
            return View();
        }

        [HttpPost]
        public string GetDetailsOrders(string args)
        {
            List<DetailOrders> detailOrder = new List<DetailOrders>();
            var jsSerializer = new JavaScriptSerializer();
            if (!string.IsNullOrEmpty(args))
            {
                
                var argsAsObject = jsSerializer.Deserialize<Client>(args);
                
                using (var dbContext = new ShopContext())
                {
                    var ordersList = dbContext.Orders.Where(u => u.ClientCode == argsAsObject.ClientCode).ToList();
                    var orderStringList = dbContext.OrderStringTable.ToList();

                    var productsList = dbContext.Product.ToList();

                    Product product = new Product();
                    List<OrderString> orderStringByClient = new List<OrderString>();
                    foreach (var order in ordersList)
                    {
                        List<DetailOrderString> detailOrderString = new List<DetailOrderString>();

                        orderStringByClient = orderStringList.Where(u => u.OrderCode == order.OrderCode).ToList();
                        foreach (var orderString in orderStringByClient)
                        {

                            product = productsList.FirstOrDefault(u => u.ProductCode == orderString.ProductCode);
                            detailOrderString.Add(new DetailOrderString()
                            {
                                ProductCode = orderString.ProductCode,
                                ProductName = product.ProductName,
                                Price = orderString.Price,
                                Quantity = orderString.Quantity,
                                TotalAmount = orderString.TotalAmount
                            });
                        }
                        detailOrder.Add(new DetailOrders()
                        {
                            OrderDate = order.OrederDate.HasValue ? order.OrederDate.Value.ToShortDateString() : "&nbsp",
                            Order = order,
                            DetailOrederString = detailOrderString,
                        });
                    }

                    
                }
            }

            var returnValue = jsSerializer.Serialize(detailOrder);
            return returnValue;
        }
    }
}