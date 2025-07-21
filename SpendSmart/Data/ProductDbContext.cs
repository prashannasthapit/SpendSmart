using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace SpendSmart.Data;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    public DbSet<ProductType> ProductTypes =>  Set<ProductType>();
    
    public DbSet<SubType> SubTypes =>  Set<SubType>();
    public DbSet<Product> Products =>  Set<Product>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id = 1, ProductTypeName = "Apparel" },
            new ProductType { Id = 2, ProductTypeName = "Mobile Phone" },
            new ProductType { Id = 3, ProductTypeName = "Laptop" },
            new ProductType { Id = 4, ProductTypeName = "Stationery" },
            new ProductType { Id = 5, ProductTypeName = "Headphones" }
        );

        modelBuilder.Entity<SubType>().HasData(
            new SubType { Id = 1, SubTypeName = "T-Shirt", ProductTypeId = 1 },
            new SubType { Id = 2, SubTypeName = "Jeans", ProductTypeId = 1 },
            new SubType { Id = 3, SubTypeName = "iPhone", ProductTypeId = 2 },
            new SubType { Id = 4, SubTypeName = "Android", ProductTypeId = 2 },
            new SubType { Id = 5, SubTypeName = "Gaming Laptop", ProductTypeId = 3 },
            new SubType { Id = 6, SubTypeName = "Ultrabook", ProductTypeId = 3 },
            new SubType { Id = 7, SubTypeName = "Notebook", ProductTypeId = 4 },
            new SubType { Id = 8, SubTypeName = "Pen", ProductTypeId = 4 },
            new SubType { Id = 9, SubTypeName = "Wireless", ProductTypeId = 5 },
            new SubType { Id = 10, SubTypeName = "Wired", ProductTypeId = 5 }
        );

    }
}