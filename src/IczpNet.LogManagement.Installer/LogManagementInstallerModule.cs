using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace IczpNet.LogManagement;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class LogManagementInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LogManagementInstallerModule>();
        });
    }
}
