using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IczpNet.LogManagement.EntityFrameworkCore;

public class LogManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<LogManagementHttpApiHostMigrationsDbContext>
{
    public LogManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<LogManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("LogManagement"));

        return new LogManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
