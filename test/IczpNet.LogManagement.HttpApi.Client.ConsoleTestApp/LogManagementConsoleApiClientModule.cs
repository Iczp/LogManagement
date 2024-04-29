using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace IczpNet.LogManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LogManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class LogManagementConsoleApiClientModule : AbpModule
{

}
