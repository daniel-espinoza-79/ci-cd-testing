using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using UserService.Infrastructure.Context;

namespace UserServiceMigration;

public class Program{
    public static void Main()
    {
        Console.WriteLine("Running UserServiceMigration");
    }
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PostgresContext>
{
    public PostgresContext CreateDbContext(string[] args)
    {

        var optionsBuilder = new DbContextOptionsBuilder<PostgresContext>();
        optionsBuilder.UseNpgsql(
            Environment.GetEnvironmentVariable("USER_SERVICE_CONNECTION_STRING") ?? throw new ("USER_SERVICE_CONNECTION_STRING was not set"),
            b => b.MigrationsAssembly("UserServiceMigration"))
            .LogTo(Console.WriteLine, LogLevel.Information);
        return new PostgresContext(optionsBuilder.Options);
    }
}