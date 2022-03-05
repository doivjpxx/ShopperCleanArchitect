using Microsoft.EntityFrameworkCore;
using Shop.ApplicationCore.Entities;

namespace Shop.Infrastructure.Persistence.Context;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
}