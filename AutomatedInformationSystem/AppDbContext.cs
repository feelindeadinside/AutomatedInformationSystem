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
            optionsBuilder.UseSqlite("Data Source=store.db");  // Подключение к базе данных
        }

        // Дополнительные настройки моделей
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка уникальности имени пользователя
            modelBuilder.Entity<User>()
                .HasIndex(u => u.username)
                .IsUnique();

            // Настройка уникальности имени продукта
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.name)
                .IsUnique();

            // Настройка связей между сущностями
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