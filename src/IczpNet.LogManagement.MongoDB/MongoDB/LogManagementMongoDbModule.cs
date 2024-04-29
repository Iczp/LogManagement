using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.AuditLogging.MongoDB;
using Volo.Abp.Identity.MongoDB;

namespace IczpNet.LogManagement.MongoDB;

[DependsOn(
    typeof(LogManagementDomainModule),
    typeof(AbpMongoDbModule)
    )]
[DependsOn(typeof(AbpAuditLoggingMongoDbModule))]
    [DependsOn(typeof(AbpIdentityMongoDbModule))]
    public class LogManagementMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<LogManagementMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
