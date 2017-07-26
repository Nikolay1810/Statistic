using InvertGroup.Models.Clients;
using InvertGroup.Models.Order;
using InvertGroup.Models.OrderStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvertGroup.CommonCode
{
    public class Common
    {
        public Common()
        {

        }
        public static double CalculateTotalAmount(List<Client> clientList, List<Orders> ordersList, List<OrderString> ordersStringList)
        {
            double totalSum = 0;
            double sum;
            List<OrderString> orderStringListSorted = new List<OrderString>();

            foreach (var client in clientList)
            {
                List<Orders> ordersByClient = new List<Orders>();
                ordersByClient.AddRange(ordersList.Where(u => u.ClientCode == client.ClientCode).ToList());
                sum = 0;
                foreach (var order in ordersByClient)
                {
                    orderStringListSorted = ordersStringList.Where(u => u.OrderCode == order.OrderCode).ToList();
                    sum += orderStringListSorted.Sum(u => u.TotalAmount);
                }
                totalSum += sum;
            }
            return totalSum; 
        }
    }
}