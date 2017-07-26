using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using InvertGroup.Models.Categories;
using InvertGroup.Models.Clients;
using InvertGroup.Models.Products;
using InvertGroup.Models.Order;
using InvertGroup.Models.OrderStrings;
using System.Data.SqlClient;

namespace InvertGroup.Models.Shop
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopContext")
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> ClientTable { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderString> OrderStringTable { get; set; }

       
    }
}