namespace Order_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        public int? OrderID { get; set; }

        public int CustomerID { get; set; }

        [Required]
        [StringLength(20)]
        public string CustomerFirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string CustomerSurname { get; set; }

        [Required]
        [StringLength(20)]
        public string CustomerAddress { get; set; }

        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductsOrdered { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }
    }
}
