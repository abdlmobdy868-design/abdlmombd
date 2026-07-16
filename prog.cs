-----structure-------
P02_SalesDatabase
├── Data
│ └── SalesContext.cs
├── Models
│ ├── Product.cs
│ ├── Customer.cs
│ ├── Store.cs
│ └── Sale.cs
└── Program.cs
----------------------product modl---------------------
using System.ComponentModel.DataAnnotations;

namespace P02_SalesDatabase.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public double Quantity { get; set; }
        public decimal Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
----------------customer-model----------------
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_SalesDatabase.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(80)]
        [Column(TypeName = "varchar(80)")]
        public string Email { get; set; }

        [Required]
        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
-------------store model------------
    using System.ComponentModel.DataAnnotations;

namespace P02_SalesDatabase.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
-----------------------------sales/model---------------
    namespace P02_SalesDatabase.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer { get; set; }

        public int ProductId { get; set; }
        public virtual Product { get; set; }

        public int StoreId { get; set; }
        public virtual Store { get; set; }
    }
}
----------------------salescontext/model-------------------
using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models;

namespace P02_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SalesDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
               .Property(s => s.Date)
               .HasDefaultValueSql("GETDATE()");
        }
    }
}
----------------------------------------------mirgation------------------------------------
Add-Migration InitialCreate
Add-Migration ProductDescriptionAdded
Add-Migration SaleDateDefault
Update-Database

