using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace IczpNet.LogManagement.EntityFrameworkCore;

public class LogManagementHttpApiHostMigrationsDbContext : AbpDbContext<LogManagementHttpApiHostMigrationsDbContext>
{
    public LogManagementHttpApiHostMigrationsDbContext(DbContextOptions<LogManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureLogManagement();
    }
}
