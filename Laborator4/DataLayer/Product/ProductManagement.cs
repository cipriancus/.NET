using Microsoft.EntityFrameworkCore;


namespace Laborator4
{
    public class ProductManagement : DbContext
    {
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
                .IsRequired()
                .ToString()
                .Equals(@"^07+[0-9]{8}$");
            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Email)
                .IsRequired()
                .ToString()
                .Equals(@"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$");     
           
        }
        public DbSet<Customer> Clienti { get; set; }
        public DbSet<Product> Produse { get; set; }
        public DbSet<Category> Categorii { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EntityModel;Trusted_Connection=True;");
        }
    }
}
