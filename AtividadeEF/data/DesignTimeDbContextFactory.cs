using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseMySql(
            "server=localhost;database=meudatabase;user=Izabelly Márcia;password=1234",
            new MySqlServerVersion(new Version(8, 0, 34))
        );
        return new AppDbContext(optionsBuilder.Options);
    }
}
