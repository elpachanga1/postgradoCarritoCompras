namespace CarritoComprasBackend.Data;

using CarritoComprasBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {
    protected readonly IConfiguration Configuration;

    public AppDbContext(IConfiguration configuration) {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Product> Products { get; set; }
}