using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomatedInformationSystem
{
    public class User
    {
        [Key]  // Указываем, что это первичный ключ
        public int user_id { get; set; }

        [Required]
        [MaxLength(100)]
        public string username { get; set; }

        [Required]
        [MaxLength(256)]
        public string password { get; set; }

        [Required]
        [MaxLength(50)]
        public string role { get; set; }
    }

    public class Product
    {
        [Key]  // Указываем, что это первичный ключ
        public int product_id { get; set; }

        [Required]
        [MaxLength(200)]
        public string name { get; set; }

        [Required]
        public double price { get; set; }

        public DateTime? expiration_date { get; set; }
    }

    public class Customer
    {
        [Key]  // Указываем, что это первичный ключ
        public int customer_id { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; }

        [MaxLength(20)]
        public string phone { get; set; }

        [MaxLength(100)]
        public string email { get; set; }
    }

    public class Sales
    {
        [Key]  // Указываем, что это первичный ключ
        public int sales_id { get; set; }

        [ForeignKey("Product")]  // Указываем, что это внешний ключ на таблицу Product
        public int product_id { get; set; }

        [ForeignKey("Customer")]  // Указываем, что это внешний ключ на таблицу Customer
        public int customer_id { get; set; }

        [ForeignKey("User")]  // Указываем, что это внешний ключ на таблицу User
        public int user_id { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public DateTime sale_date { get; set; }

        // Навигационные свойства
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
    }
}
