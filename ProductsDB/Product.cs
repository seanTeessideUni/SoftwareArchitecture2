namespace ProductsDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }
    }
}
