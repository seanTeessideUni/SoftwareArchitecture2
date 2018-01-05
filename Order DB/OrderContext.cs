namespace Order_DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OrderContext : DbContext
    {
        public OrderContext()
            : base("name=OrderContext")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.CustomerFirstName)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.CustomerSurname)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.CustomerAddress)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.ProductsOrdered)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);
        }
    }
}
