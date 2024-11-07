using Microsoft.EntityFrameworkCore;

namespace AutomatedInformationSystem
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=store.db"); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>()
                .HasIndex(u => u.username)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.name)
                .IsUnique();

            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.product_id);

            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.customer_id);

            modelBuilder.Entity<Sales>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.user_id);
        }
    }
}