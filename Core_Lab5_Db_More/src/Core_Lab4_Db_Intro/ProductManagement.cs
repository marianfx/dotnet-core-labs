using Core_Lab5_Db_More.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Lab5_Db_More
{
    public class ProductManagement: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=fx.;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                .IsRequired();
            // EF7 Error => does not support regular expressions annotations.
            //.HasAnnotation("RegularExpression", 
            //new RegularExpressionAttribute(@"\+407\d{8}"));

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Email)
                .IsRequired();
                //.HasAnnotation("RegularExpression", 
                //new RegularExpressionAttribute(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"));

            base.OnModelCreating(modelBuilder);

        }
    }
}
