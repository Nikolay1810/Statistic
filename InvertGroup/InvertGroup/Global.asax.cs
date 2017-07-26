using InvertGroup.Models.Shop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InvertGroup
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ShopContext context = new ShopContext();
            var sqlConn = (SqlConnection)context.Database.Connection;
            sqlConn.Open();
            try
            {

                var command = new SqlCommand("exec insertDataTables", sqlConn);
                int result = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConn.Close();
            }
        }
    }
}
