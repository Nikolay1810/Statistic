using InvertGroup.CommonCode;
using InvertGroup.Models.Order;
using InvertGroup.Models.OrderStrings;
using InvertGroup.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using InvertGroup.Models.StatisticsByOrder;
using System.Web.Script.Serialization;

namespace InvertGroup.Controllers.Statistics
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Statistics()
        {
            return View();
        }

        [HttpPost]
        public string GetStatistics()
        {
            Statistic statistic = new Statistic();
            using (var dbContext = new ShopContext())
            {
                var clientsList = dbContext.ClientTable.ToList();
                var vipCLients = clientsList.Where(u => u.CategoryId == 4).ToList();
                var topClients = clientsList.Where(u => u.CategoryId == 3).ToList();
                var middleClients = clientsList.Where(u => u.CategoryId == 2).ToList();
                var usuallyClients = clientsList.Where(u => u.CategoryId == 1).ToList();

                var ordersList = dbContext.Orders.ToList();
                var ordersStringList = dbContext.OrderStringTable.ToList();


                statistic.CountUsuallyClients = usuallyClients.Count;
                statistic.CountMiddleClients = middleClients.Count;
                statistic.CountTopClients = topClients.Count;
                statistic.CountVipClients = vipCLients.Count;

                statistic.UsuallyTotalSum = Common.CalculateTotalAmount(usuallyClients, ordersList, ordersStringList);
                statistic.MiddleTotalSum = Common.CalculateTotalAmount(middleClients, ordersList, ordersStringList);
                statistic.TopTotalSum = Common.CalculateTotalAmount(topClients, ordersList, ordersStringList);
                statistic.VipTotalSum = Common.CalculateTotalAmount(vipCLients, ordersList, ordersStringList);

            }
            var jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(statistic);
        }
    }
}