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
            Environment.GetEnvironmentVariable("USER_POSTGRES_SQL_CONNECTION") ?? throw new ("USER_POSTGRES_SQL_CONNECTION was not set"),
            b => b.MigrationsAssembly("UserServiceMigration"))
            .LogTo(Console.WriteLine, LogLevel.Information);
        return new PostgresContext(optionsBuilder.Options);
    }
}