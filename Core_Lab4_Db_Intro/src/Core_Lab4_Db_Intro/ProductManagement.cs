using Microsoft.EntityFrameworkCore;

namespace Core_Lab4_Db_Intro
{
    public class ProductManagement: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Address)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.PhoneNumber)
                .IsRequired()
                .HasAnnotation("RegularExpression", @"\+407\d{8}");

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Email)
                .IsRequired()
                .HasAnnotation("RegularExpression", @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }
    }
}
