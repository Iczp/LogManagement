using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using IczpNet.AbpCommons.EntityFrameworkCore;

namespace IczpNet.LogManagement.EntityFrameworkCore;

[DependsOn(
    typeof(LogManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
[DependsOn(typeof(AbpAuditLoggingEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpIdentityEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpCommonsEntityFrameworkCoreModule))]
public class LogManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<LogManagementDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        context.Services.AddAbpDbContext<AuditLoggingDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
            //options.AddRepository<AuditLogAction, EfCoreAuditLogRepository>();
            //options.AddRepository<EntityChange, EfCoreAuditLogRepository>();
            //options.AddRepository<EntityPropertyChange, EfCoreAuditLogRepository>();
        });
    }
}
