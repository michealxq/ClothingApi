using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using P1API.Models;
using P1API.Models.Domains;

namespace P1API.Data
{
    public class ClothingDbContext : DbContext
    {
        public ClothingDbContext(DbContextOptions<ClothingDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)"); // Precision: 18, Scale: 2


            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18, 2)"); // Precision: 18, Scale: 2


            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasColumnType("decimal(18, 2)"); // Precision: 18, Scale: 2

            


            // Unique constraint on User Email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            

            base.OnModelCreating(modelBuilder);


            
            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Men",
                    ParentCategoryId = 1
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Women",
                    ParentCategoryId = 2
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Jacket",
                    ParentCategoryId = 1
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Shorts",
                    ParentCategoryId = 1
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Shirts",
                    ParentCategoryId = 1
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "Hoodies",
                    ParentCategoryId = 1
                },
                new Category()
                {
                    CategoryId = 7,
                    CategoryName = "T-Shirt",
                    ParentCategoryId = 1
                },
                new Category()
                {
                    CategoryId = 8,
                    CategoryName = "Jacket",
                    ParentCategoryId = 2
                },
                new Category()
                {
                    CategoryId = 9,
                    CategoryName = "Shorts",
                    ParentCategoryId = 2
                },
                new Category()
                {
                    CategoryId = 10,
                    CategoryName = "Shirts",
                    ParentCategoryId = 2
                },
                new Category()
                {
                    CategoryId = 11,
                    CategoryName = "Hoodies",
                    ParentCategoryId = 2
                },
                new Category()
                {
                    CategoryId = 12,
                    CategoryName = "T-Shirt",
                    ParentCategoryId = 2
                }

            };

            
            modelBuilder.Entity<Category>().HasData(categories);



            var product = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Blue breeze jeans jacket",
                    Description = "Upgrade your wardrobe with our timeless denim jacket. Crafted for durability and style, it's the perfect versatile piece for any occasion.",
                    Price = 35.49M,
                    StockQuantity =10,
                    CategoryId = 8

                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Rebel roadster leather jacket",
                    Description = "Elevate your style with our premium leather jacket. Crafted from high-quality leather, it offers sleek sophistication and lasting comfort for any occasion.",
                    Price = 80.49M,
                    StockQuantity =10,
                    CategoryId = 8

                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "City comfort shorts",
                    Description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis.",
                    Price = 40.00M,
                    StockQuantity =10,
                    CategoryId = 4

                },
                new Product()
                {
                    ProductId = 4,
                    ProductName = "Wanderer wave men shirt",
                    Description = "Introducing our stylish shirt, meticulously crafted for comfort and versatility, a must-have for every wardrobe.",
                    Price = 105.49M,
                    StockQuantity =10,
                    CategoryId = 5

                },
                new Product()
                {
                    ProductId = 5,
                    ProductName = "Bluebird belle dress",
                    Description = "Introducing our elegant dress, designed for timeless style and effortless sophistication.",
                    Price = 47.00M,
                    StockQuantity =10,
                    CategoryId = 2

                },
                new Product()
                {
                    ProductId = 6,
                    ProductName = "Denim delight jacket",
                    Description = "Upgrade your wardrobe with our timeless denim jacket. Crafted for durability and style, it's the perfect versatile piece for any occasion.",
                    Price = 95.00M,
                    StockQuantity =10,
                    CategoryId = 8

                },
                new Product()
                {
                    ProductId = 7,
                    ProductName = "Silver shadow jacket",
                    Description = "Introducing our sleek jacket, crafted for timeless style and enduring comfort.",
                    Price = 105.00M,
                    StockQuantity =10,
                    CategoryId = 8

                },
                new Product()
                {
                    ProductId = 8,
                    ProductName = "Smoke symphony sweater",
                    Description = "Introducing our sleek sweater, crafted for timeless style and enduring comfort.",
                    Price = 120.49M,
                    StockQuantity =10,
                    CategoryId = 2

                },
                new Product()
                {
                    ProductId = 9,
                    ProductName = "Caramel charm jacket",
                    Description = "Elevate your style with our premium leather jacket. Crafted from high-quality leather, it offers sleek sophistication and lasting comfort for any occasion.",
                    Price = 49.00M,
                    StockQuantity =10,
                    CategoryId = 8

                },
                new Product()
                {
                    ProductId = 10,
                    ProductName = "Dark knight defender jacket",
                    Description = "Introducing our sleek jacket, crafted for timeless style and enduring comfort.",
                    Price = 120.49M,
                    StockQuantity =10,
                    CategoryId = 3

                },
                new Product()
                {
                    ProductId = 11,
                    ProductName = "Denim dreamer shorts",
                    Description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos.",
                    Price = 79.49M,
                    StockQuantity =10,
                    CategoryId = 9

                },
                new Product()
                {
                    ProductId = 12,
                    ProductName = "Blackbird bloom t-shirt",
                    Description = "Introducing our stylish t-shirt, meticulously crafted for comfort and versatility, a must-have for every wardrobe.",
                    Price = 33.00M,
                    StockQuantity =10,
                    CategoryId = 12

                },
                new Product()
                {
                    ProductId = 13,
                    ProductName = "Midnight majesty t-shirt",
                    Description = "Introducing our stylish t-shirt, meticulously crafted for comfort and versatility, a must-have for every wardrobe.",
                    Price = 42.00M,
                    StockQuantity =10,
                    CategoryId = 7

                },
                new Product()
                {
                    ProductId = 14,
                    ProductName = "Blackout bomber jacket",
                    Description = "Introducing our sleek jacket, crafted for timeless style and enduring comfort.",
                    Price = 35.49M,
                    StockQuantity =10,
                    CategoryId = 3

                }

                



            };
            modelBuilder.Entity<Product>().HasData(product);


        }




    }


}
