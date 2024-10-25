using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductStoreContext
    {
        public class ProductStore : DbContext
        {
            public ProductStore() { }
            public DbSet<Category> Categories { get; set; }
            public DbSet<AccountMember> Accounts { get; set; }
            public DbSet<Product> Products { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //var builder = new ConfigurationBuilder()
                //    .SetBasePath(Directory.GetCurrentDirectory())
                //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //IConfigurationRoot configuration = builder.Build();
                //optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProductStoreDB"));
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(GetConnectionString());
                }
            }

            string GetConnectionString()
            {
                IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                return config["ConnectionString:ProductStoreDB"];
            } 

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Category>()
                    .Property(category => category.CategoryName).IsRequired()
                    .HasMaxLength(40);
                modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Beverages" },
                    new Category { CategoryId = 2, CategoryName = "Condiments" },
                    new Category { CategoryId = 3, CategoryName = "Confections" }
                    );

                modelBuilder.Entity<AccountMember>()
                    .Property(account => account.FullName).IsRequired()
                    .HasMaxLength(40);
                modelBuilder.Entity<AccountMember>().HasData(
                    new AccountMember { MemberId = "PS0001", MemberPassword = "@1", FullName="Nguyen A", EmailAddress = "mem01@gmail.com", MemberRole = 1 }
                    );

                modelBuilder.Entity<Product>()
                    .Property(product => product.ProductName).IsRequired()
                    .HasMaxLength(40);
                modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, ProductName = "chai", CategoryId = 3, UnitsInStock = 12, UnitPrice = 18 },
                    new Product { ProductId = 2, ProductName = "chang", CategoryId = 1, UnitsInStock = 23, UnitPrice = 19 },
                    new Product { ProductId = 3, ProductName = "aniseed", CategoryId = 2, UnitsInStock = 23, UnitPrice = 10 }
                    );
            }
        }
    }
}
