using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace IczpNet.LogManagement.MongoDB;

[DependsOn(
    typeof(LogManagementTestBaseModule),
    typeof(LogManagementMongoDbModule)
    )]
public class LogManagementMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}
