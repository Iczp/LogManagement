using Volo.Abp.Reflection;

namespace IczpNet.LogManagement.Permissions;

public class LogManagementPermissions
{
    public const string GroupName = "LogManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(LogManagementPermissions));
    }

    public class AuditLogPermissions
    {
        public const string Default = GroupName + "." + nameof(AuditLogPermissions);
        public const string GetItem = Default + "." + nameof(GetItem);
        public const string GetList = Default + "." + nameof(GetList);
    }

    public class AuditLogActionPermissions
    {
        public const string Default = GroupName + "." + nameof(AuditLogActionPermissions);
        public const string GetItem = Default + "." + nameof(GetItem);
        public const string GetList = Default + "." + nameof(GetList);
    }

    public class EntityPropertyChangePermissions
    {
        public const string Default = GroupName + "." + nameof(EntityPropertyChangePermissions);
        public const string GetItem = Default + "." + nameof(GetItem);
        public const string GetList = Default + "." + nameof(GetList);
    }

    public class EntityChangePermissions
    {
        public const string Default = GroupName + "." + nameof(EntityChangePermissions);
        public const string GetItem = Default + "." + nameof(GetItem);
        public const string GetList = Default + "." + nameof(GetList);
    }


    public class SecurityLogPermissions
    {
        public const string Default = GroupName + "." + nameof(SecurityLogPermissions);
        public const string GetItem = Default + "." + nameof(GetItem);
        public const string GetList = Default + "." + nameof(GetList);
        public const string GroupByActionPolicyName = Default + "." + nameof(GroupByActionPolicyName);
    }
    public class CurrentUserSecurityLogPermissions
    {
        public const string Default = GroupName + "." + nameof(CurrentUserSecurityLogPermissions);
        public const string GetItem = Default + "." + nameof(GetItem);
        public const string GetList = Default + "." + nameof(GetList);
        public const string GroupByActionPolicyName = Default + "." + nameof(GroupByActionPolicyName);
    }
}
