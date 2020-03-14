using Microsoft.EntityFrameworkCore;
using StoreEFtest.Model.Entities;

namespace StoreEFtest.Model
{
    public class Context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=localhost;DataBase=Store;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("products", "production");
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasColumnName("product_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasColumnName("product_name");
            modelBuilder.Entity<Product>()
                .Property(p => p.BrandId)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.CategoryId)
                .HasColumnName("category_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.ModelYear)
                .HasColumnName("model_year");
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductPrice)
                .HasColumnName("list_price");

            modelBuilder.Entity<Brand>()
                .ToTable("brands", "production");
            modelBuilder.Entity<Brand>()
                .Property(b => b.Id)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Brand>()
                .Property(b => b.Name)
                .HasColumnName("brand_name");

            modelBuilder.Entity<Category>()
                .ToTable("categories", "production");
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .HasColumnName("category_id");
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasColumnName("category_name");

            modelBuilder.Entity<Stock>()
                .ToTable("stocks", "production");
            modelBuilder.Entity<Stock>()
                .Property(s => s.StoreId)
                .HasColumnName("store_name");
            modelBuilder.Entity<Stock>().
                Property(s => s.ProductId)
                .HasColumnName("product_name");
            modelBuilder.Entity<Stock>()
                .Property(s => s.Quantity)
                .HasColumnName("quantity");
            modelBuilder.Entity<Stock>()
                .HasKey(sp => new { sp.StoreId, sp.ProductId });

            modelBuilder.Entity<Store>()
                .ToTable("stores", "sales");
            modelBuilder.Entity<Store>()
                .Property(s => s.Id)
                .HasColumnName("store_id");
            modelBuilder.Entity<Store>()
                .Property(s => s.Name)
                .HasColumnName("store_name");
            modelBuilder.Entity<Store>()
                .Property(s => s.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Store>()
                .Property(s => s.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Store>()
                .Property(s => s.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Store>()
                .Property(s => s.City)
                .HasColumnName("city");
            modelBuilder.Entity<Store>()
                .Property(s => s.State)
                .HasColumnName("state");
            modelBuilder.Entity<Store>()
                .Property(s => s.ZipCode)
                .HasColumnName("zip_codee");

            modelBuilder.Entity<Customer>()
                .ToTable("customers", "sales");
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .HasColumnName("customer_id");
            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Customer>()
                .Property(c => c.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Customer>()
                .Property(c => c.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Customer>()
                .Property(c => c.City)
                .HasColumnName("city");
            modelBuilder.Entity<Customer>()
                .Property(c => c.State)
                .HasColumnName("state");
            modelBuilder.Entity<Customer>()
                .Property(c => c.ZipCode)
                .HasColumnName("zip_code");

            modelBuilder.Entity<Staff>()
                .ToTable("staffs", "sales");
            modelBuilder.Entity<Staff>()
                .Property(s => s.Id)
                .HasColumnName("staff_id");
            modelBuilder.Entity<Staff>()
                .Property(s => s.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Staff>()
                .Property(s => s.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Staff>()
                .Property(s => s.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Staff>()
                .Property(s => s.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Staff>()
                .Property(s => s.IsActive)
                .HasColumnName("active");
            modelBuilder.Entity<Staff>()
                .Property(s => s.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Staff>()
                .Property(s => s.ManagerId)
                .HasColumnName("manager_id");

            modelBuilder.Entity<Order>()
                .ToTable("orders", "sales");
            modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .HasColumnName("order_id");
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerId)
                .HasColumnName("customer_id");
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderStatus)
                .HasColumnName("order_status");
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .HasColumnName("order_date");
            modelBuilder.Entity<Order>()
                .Property(o => o.RequiredDate)
                .HasColumnName("required_date");
            modelBuilder.Entity<Order>()
                .Property(o => o.ShippedDate)
                .HasColumnName("shipped_date");
            modelBuilder.Entity<Order>()
                .Property(o => o.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Order>()
                .Property(o => o.StaffId)
                .HasColumnName("staff_id");
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Store)
                    .WithMany(s => s.Orders)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
                .ToTable("order_items", "sales");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.OrderId)
                .HasColumnName("order_id");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Quantity)
                .HasColumnName("quantity");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Price)
                .HasColumnName("list_price");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Discount)
                .HasColumnName("discount");
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });
        }
    }
}
