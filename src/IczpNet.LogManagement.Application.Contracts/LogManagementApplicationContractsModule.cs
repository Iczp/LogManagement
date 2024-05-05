using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Volo.Abp.Identity;
using IczpNet.AbpCommons;

namespace IczpNet.LogManagement;

[DependsOn(
    typeof(LogManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
[DependsOn(typeof(AbpIdentityApplicationContractsModule))]
[DependsOn(typeof(AbpCommonsApplicationContractsModule))]
public class LogManagementApplicationContractsModule : AbpModule
{

}
