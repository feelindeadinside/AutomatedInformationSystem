using Microsoft.EntityFrameworkCore;

namespace AutomatedInformationSystem
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sales> Sales { get; set; }

        // Конфигурация подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=store.db");
        }

        // Настройка моделей
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Уникальные индексы
            modelBuilder.Entity<User>()
                .HasIndex(u => u.username)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasIndex(p => p.name)
                .IsUnique();

            // Настройки для Sales

            // Связь с Product (много к одному)
            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Product)
                .WithMany()  // Продукт может иметь несколько продаж
                .HasForeignKey(s => s.product_id)  // Внешний ключ
                .OnDelete(DeleteBehavior.Restrict);  // Запрещаем каскадное удаление

            // Связь с Customer (много к одному)
            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Customer)
                .WithMany()  // Клиент может иметь несколько продаж
                .HasForeignKey(s => s.customer_id)
                .OnDelete(DeleteBehavior.Restrict);  // Запрещаем каскадное удаление

            // Связь с User (много к одному)
            modelBuilder.Entity<Sales>()
                .HasOne(s => s.User)
                .WithMany()  // Пользователь может иметь несколько продаж
                .HasForeignKey(s => s.user_id)
                .OnDelete(DeleteBehavior.Restrict);  // Запрещаем каскадное удаление
        }
    }
}
