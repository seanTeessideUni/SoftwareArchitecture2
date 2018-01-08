using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ViewOrderHistory.Models
{
    public class MockProductsContext
    {
        public class ProductsContext : DbContext
        {
            public virtual DbSet<MockProducts> Products { get; set; }
           // public virtual DbSet<MockProducts> Price { get; set; }
        }

        public class Products
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductPrice { get; set; }
        }
    }
}
