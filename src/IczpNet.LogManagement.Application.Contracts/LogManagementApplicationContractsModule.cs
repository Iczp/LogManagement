using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Volo.Abp.Identity;

namespace IczpNet.LogManagement;

[DependsOn(
    typeof(LogManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
[DependsOn(typeof(AbpIdentityApplicationContractsModule))]
    public class LogManagementApplicationContractsModule : AbpModule
{

}
