using IczpNet.LogManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace IczpNet.LogManagement;

public abstract class LogManagementController : AbpControllerBase
{
    protected LogManagementController()
    {
        LocalizationResource = typeof(LogManagementResource);
    }
}
