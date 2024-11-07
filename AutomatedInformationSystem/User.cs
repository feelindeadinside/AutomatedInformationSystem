using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomatedInformationSystem
{
    public class User
    {
        [Key]  
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
        [Key]  
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
        [Key]  
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
        [Key]  
        public int sales_id { get; set; }

        [ForeignKey("Product")]  
        public int product_id { get; set; }

        [ForeignKey("Customer")] 
        public int customer_id { get; set; }

        [ForeignKey("User")]  
        public int user_id { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public DateTime sale_date { get; set; }

        
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
    }
}
