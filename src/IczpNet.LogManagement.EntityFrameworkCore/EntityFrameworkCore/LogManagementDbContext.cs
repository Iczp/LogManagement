using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace IczpNet.LogManagement.EntityFrameworkCore;

[ConnectionStringName(LogManagementDbProperties.ConnectionStringName)]
public class LogManagementDbContext : AbpDbContext<LogManagementDbContext>, ILogManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public LogManagementDbContext(DbContextOptions<LogManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureLogManagement();
        builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
        }
}
