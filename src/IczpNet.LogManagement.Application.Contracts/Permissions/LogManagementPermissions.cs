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
        public const string GroupByApplicationName = Default + "." + nameof(GroupByApplicationName);
        public const string GroupByClientId = Default + "." + nameof(GroupByClientId);
        public const string GroupByHttpMethod = Default + "." + nameof(GroupByHttpMethod);
        public const string GroupByHttpStatusCode = Default + "." + nameof(GroupByHttpStatusCode);
    }

    public class AuditLogActionPermissions
    {
        public const string Default = GroupName + "." + nameof(AuditLogActionPermissions);
        public const string GetItem = Default + "." + nameof(GetItem);
        public const string GetList = Default + "." + nameof(GetList);
        public const string GroupByServiceName = Default + "." + nameof(GroupByServiceName);
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
        public const string GroupByAction = Default + "." + nameof(GroupByAction);
        public const string GroupByApplicationName = Default + "." + nameof(GroupByApplicationName);
        public const string GroupByClientId = Default + "." + nameof(GroupByClientId);
    }

    public class CurrentUserSecurityLogPermissions
    {
        public const string Default = GroupName + "." + nameof(CurrentUserSecurityLogPermissions);
        public const string GetItem = Default + "." + nameof(GetItem);
        public const string GetList = Default + "." + nameof(GetList);
        public const string GroupByAction = Default + "." + nameof(GroupByAction);
        public const string GroupByApplicationName = Default + "." + nameof(GroupByApplicationName);
        public const string GroupByClientId = Default + "." + nameof(GroupByClientId);
    }
}
