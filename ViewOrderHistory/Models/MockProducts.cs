using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static ViewOrderHistory.Models.MockProductsContext;


namespace ViewOrderHistory.Models
{
    public class MockProducts
    {

        public void GetAllProductsbyName()
        {
            var data = new List<Products>
            {
                new Products { ProductId = "1", ProductName = "Apple", ProductPrice = "2.00" },
                new Products { ProductId = "2", ProductName = "Pear", ProductPrice = "1.00" },
                new Products { ProductId = "3", ProductName = "Bannana", ProductPrice = "3.00" },
            }.AsQueryable();

        }
    }
}