using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Order_DB;

namespace ViewOrderHistory.Models
{

    public class ProductInfoView
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }

    }
    var result = (from lang in my_entity.LANGUAGE
                  join c in my_entity.COUNTRY
                  on lang.COUNTRY_ID equals c.ID
                  select new LangCountryModel
                  {
                      LangCol1 = lang.Col1,
                      LangCol2 = land.col2,
                      CountryCol1 = c.Col1,
                      CountryCol2 = c.Col2
                  }).ToList();
}

