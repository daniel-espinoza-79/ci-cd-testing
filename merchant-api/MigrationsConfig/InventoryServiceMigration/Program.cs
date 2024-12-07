using InventoryService.Intraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;



namespace InventoryServiceMigration;

public class Program{
    public static void Main()
    {
        Console.WriteLine("Running InventoryServiceMigration");
    }
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
{
    public InventoryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("INVENTORY_SERVICE_CONNECTION_STRING") ?? throw new("INVENTORY_SERVICE_CONNECTION_STRING environment variable is not set."),
            b => b.MigrationsAssembly("InventoryServiceMigration"))
                      .LogTo(Console.WriteLine, LogLevel.Information);
        return new InventoryDbContext(optionsBuilder.Options);
    }
}

