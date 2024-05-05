using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.Identity;
using IczpNet.AbpCommons;

namespace IczpNet.LogManagement;

[DependsOn(
    typeof(LogManagementDomainModule),
    typeof(LogManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
[DependsOn(typeof(AbpIdentityApplicationModule))]
[DependsOn(typeof(AbpCommonsApplicationModule))]
public class LogManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<LogManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<LogManagementApplicationModule>(validate: true);
        });
    }
}
