using IczpNet.LogManagement.Localization;
using Volo.Abp.Application.Services;

namespace IczpNet.LogManagement.BaseAppServices;

public abstract class LogManagementAppService : ApplicationService
{
    protected LogManagementAppService()
    {
        LocalizationResource = typeof(LogManagementResource);
        ObjectMapperContext = typeof(LogManagementApplicationModule);
    }
}
