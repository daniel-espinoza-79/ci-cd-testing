﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using PaymentService.Infrastructure.Data;

namespace PaymentServiceMigration;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Running PaymentServiceMigration");
    }
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PaymentDbContext>
{
    PaymentDbContext IDesignTimeDbContextFactory<PaymentDbContext>.CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PaymentDbContext>();
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("PAYMENT_POSTGRES_SQL_CONNECTION") ?? throw new("PAYMENT_POSTGRES_SQL_CONNECTION environment variable is not set."),
            b => b.MigrationsAssembly("PaymentServiceMigration"))
                      .LogTo(Console.WriteLine, LogLevel.Information);
        return new PaymentDbContext(optionsBuilder.Options);
    }
}
