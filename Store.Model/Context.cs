using Microsoft.EntityFrameworkCore;
using StoreEFtest.Model.Entities;
using System;

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

            #region DataSeeding
            var customer1 = new Customer()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Blob",
                City = "kh",
                Email = "bla@bla.com",
                Phone = "0572",
                State = "KhObl",
                Street = "Nauki 43a",
                ZipCode = "61111",
            };
            var customer2 = new Customer()
            {
                Id = 2,
                FirstName = "Bobik",
                LastName = "Blobik",
                City = "khar",
                Email = "blabla@bla.com",
                Phone = "057",
                State = "KhO",
                Street = "Nauki 43b",
                ZipCode = "61111",
            };
            modelBuilder.Entity<Customer>().HasData(customer1, customer2);

            var store1 = new Store
            {
                Id = 1,
                Name = "The Store",
                Phone = "057",
                Email = "store@mail.com",
                Street = "bla bla street",
                City = "bla city",
                State = "KH",
                ZipCode = "61", 
            };
            modelBuilder.Entity<Store>().HasData(store1);

            var staff1 = new Staff
            {
                Id = 1,
                FirstName = "Walk",
                LastName = "Walker",
                Email = "walk@com",
                IsActive = true,
                Phone = "555",
                StoreId = store1.Id,
            };
            var staff2 = new Staff
            {
                Id = 2,
                FirstName = "Megan",
                LastName = "Fox",
                Email = "megan@com",
                IsActive = true,
                Phone = "777",
                StoreId = store1.Id,
                ManagerId = staff1.Id,
            };
            modelBuilder.Entity<Staff>().HasData(staff1, staff2);

            var order1 = new Order
            {
                Id = 1,
                CustomerId = customer1.Id,
                OrderStatus = OrderStatuses.Received,
                OrderDate = DateTime.Today,
                RequiredDate = DateTime.Today.AddDays(2),
                ShippedDate = DateTime.Today.AddDays(1),
                StoreId = store1.Id,
                StaffId = staff2.Id,
            };
            var order2 = new Order
            {
                Id = 2,
                CustomerId = customer1.Id,
                OrderStatus = OrderStatuses.Shipped,
                OrderDate = DateTime.Today,
                RequiredDate = DateTime.Today.AddDays(3),
                ShippedDate = DateTime.Today,
                StoreId = store1.Id,
                StaffId = staff1.Id,
            };
            modelBuilder.Entity<Order>().HasData(order1, order2);

            var brand1 = new Brand
            {
                Id = 1,
                Name = "brand 1",
            };
            var brand2 = new Brand
            {
                Id = 2,
                Name = "brand 2",
            };
            modelBuilder.Entity<Brand>().HasData(brand1, brand2);

            var category1 = new Category
            {
                Id = 1,
                Name = "cat 1",
            };
            var category2 = new Category
            {
                Id = 2,
                Name = "cat 2",
            };
            modelBuilder.Entity<Category>().HasData(category1, category2);

            var product1 = new Product
            {
                Id = 1,
                Name = "product 1",
                ModelYear = new DateTime(1982, 9, 4),
                ProductPrice = 1000000,
                BrandId = brand1.Id,
                CategoryId = category1.Id,
            };
            var product2 = new Product
            {
                Id = 2,
                Name = "product 2",
                ModelYear = new DateTime(2017, 9, 22),
                ProductPrice = 1000000000,
                BrandId = brand2.Id,
                CategoryId = category2.Id,
            };
            modelBuilder.Entity<Product>().HasData(product1, product2);

            var stock1 = new Stock
            {
                Quantity = 300,
                StoreId = store1.Id,
                ProductId = product1.Id,
            };
            var stock2 = new Stock
            {
                Quantity = 200,
                StoreId = store1.Id,
                ProductId = product2.Id,
            };
            modelBuilder.Entity<Stock>().HasData(stock1, stock2);

            var orderItem1 = new OrderItem
            {
                OrderId = order1.Id,
                ProductId = product1.Id,
                Quantity = 7,
                Discount = 20,
                Price = 100,
            };
            var orderItem2 = new OrderItem
            {
                OrderId = order2.Id,
                ProductId = product2.Id,
                Quantity = 17,
                Discount = 30,
                Price = 200,
            };
            modelBuilder.Entity<OrderItem>().HasData(orderItem1, orderItem2);
            #endregion
        }
    }
}
