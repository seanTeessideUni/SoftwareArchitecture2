namespace UserDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstLineAddress)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.SecondLineAddress)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.PostCode)
                .IsFixedLength();
        }
    }
}
