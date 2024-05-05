using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.AuditLogging;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement.Identity;
using IczpNet.AbpCommons;

namespace IczpNet.LogManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(LogManagementDomainSharedModule)
)]
[DependsOn(typeof(AbpAuditLoggingDomainModule))]
[DependsOn(typeof(AbpIdentityDomainModule))]
[DependsOn(typeof(AbpPermissionManagementDomainIdentityModule))]
[DependsOn(typeof(AbpCommonsDomainModule))]
public class LogManagementDomainModule : AbpModule
{

}
