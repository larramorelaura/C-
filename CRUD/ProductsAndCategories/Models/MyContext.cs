#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategories.Models;

public class MyContext : DbContext 
{     
    public MyContext(DbContextOptions options) : base(options) { }   

    public DbSet<Category> Categories { get; set; } 
    public DbSet<Product> Products { get; set; } 
    public DbSet<ProductAndCategory> ProductsAndCategories{ get; set; } 
}


