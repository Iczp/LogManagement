using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.EntityFrameworkCore;

namespace IczpNet.LogManagement.EntityFrameworkCore;

[ConnectionStringName(AbpAuditLoggingDbProperties.ConnectionStringName)]
public class AuditLoggingDbContext : AbpDbContext<AuditLoggingDbContext>, IAuditLoggingDbContext
{
    public DbSet<AuditLog> AuditLog { get; }

    public DbSet<AuditLogAction> AuditLogAction { get; }

    public DbSet<EntityChange> EntityChange { get; }

    public DbSet<EntityPropertyChange> EntityPropertyChange { get; }

    public AuditLoggingDbContext(DbContextOptions<AuditLoggingDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAuditLogging();
    }
}
