using IczpNet.LogManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace IczpNet.LogManagement.Permissions;

public class LogManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LogManagementPermissions.GroupName, L("Permission:LogManagement"));

        myGroup.AddPermissions<LogManagementPermissions>(x => L($"Permission:{x}"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LogManagementResource>(name);
    }
}
