using ItemsCrud.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemsCrud.Persistence;

public class ItemsContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ItemsContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options
            .UseNpgsql(_configuration.GetConnectionString("ItemsDatabase"))
            .UseSnakeCaseNamingConvention();
    }

    public DbSet<Item> Items { get; set; }
}