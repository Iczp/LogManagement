using IczpNet.LogManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace IczpNet.LogManagement;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(LogManagementEntityFrameworkCoreTestModule)
    )]
public class LogManagementDomainTestModule : AbpModule
{

}
