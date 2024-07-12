using IczpNet.LogManagement.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;

namespace IczpNet.LogManagement.BaseAppServices;

[ApiExplorerSettings(GroupName = LogManagementRemoteServiceConsts.ModuleName)]
public abstract class LogManagementAppService : ApplicationService
{
    protected LogManagementAppService()
    {
        LocalizationResource = typeof(LogManagementResource);
        ObjectMapperContext = typeof(LogManagementApplicationModule);
    }
}
