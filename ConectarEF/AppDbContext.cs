using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    // DbSets personalizados, se quiser adicionar depois
    // public DbSet<Algo> Algos { get; set; }
}