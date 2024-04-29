using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Identity;

namespace IczpNet.LogManagement;

[DependsOn(
    typeof(LogManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
[DependsOn(typeof(AbpIdentityHttpApiClientModule))]
    public class LogManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(LogManagementApplicationContractsModule).Assembly,
            LogManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LogManagementHttpApiClientModule>();
        });

    }
}
