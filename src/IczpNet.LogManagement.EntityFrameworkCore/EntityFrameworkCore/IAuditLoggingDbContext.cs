using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace IczpNet.LogManagement.EntityFrameworkCore;

[ConnectionStringName(AbpAuditLoggingDbProperties.ConnectionStringName)]
public interface IAuditLoggingDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<AuditLog> AuditLog { get; }

    DbSet<AuditLogAction> AuditLogAction { get; }

    DbSet<EntityChange> EntityChange { get; }

    DbSet<EntityPropertyChange> EntityPropertyChange { get; }
}
