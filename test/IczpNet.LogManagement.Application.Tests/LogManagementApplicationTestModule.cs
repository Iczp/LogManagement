using Volo.Abp.Modularity;

namespace IczpNet.LogManagement;

[DependsOn(
    typeof(LogManagementApplicationModule),
    typeof(LogManagementDomainTestModule)
    )]
public class LogManagementApplicationTestModule : AbpModule
{

}
