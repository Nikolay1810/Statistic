using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvertGroup.Models.StatisticsByOrder
{
    public class Statistic
    {
        public int CountVipClients { get; set; }
        public int CountTopClients { get; set; }
        public int CountMiddleClients { get; set; }
        public int CountUsuallyClients { get; set; }

        public double VipTotalSum { get; set; }
        public double TopTotalSum { get; set; }
        public double MiddleTotalSum { get; set; }
        public double UsuallyTotalSum { get; set; }
    }
}