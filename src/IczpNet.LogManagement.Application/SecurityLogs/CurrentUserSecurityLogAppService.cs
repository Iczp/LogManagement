using IczpNet.LogManagement.SecurityLogs.Dtos;
using IczpNet.LogManagement.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Dtos;
using IczpNet.LogManagement.BaseDtos;
using System.Linq.Expressions;

namespace IczpNet.LogManagement.SecurityLogs;

/// <summary>
/// 当前登录用户安全日志
/// </summary>
public class CurrentUserSecurityLogAppService : SecurityLogAppService, ICurrentUserSecurityLogAppService
{
    protected override string GetListPolicyName { get; set; } = LogManagementPermissions.CurrentUserSecurityLogPermissions.GetList;
    protected override string GetPolicyName { get; set; } = LogManagementPermissions.CurrentUserSecurityLogPermissions.GetItem;
    protected override string GroupByActionPolicyName { get; set; } = LogManagementPermissions.CurrentUserSecurityLogPermissions.GroupByAction;
    protected override string GroupByApplicationNamePolicyName { get; set; } = LogManagementPermissions.CurrentUserSecurityLogPermissions.GroupByApplicationName;
    protected override string GroupByClientIdPolicyName { get; set; } = LogManagementPermissions.CurrentUserSecurityLogPermissions.GroupByClientId;
    public CurrentUserSecurityLogAppService(IRepository<IdentitySecurityLog, Guid> repository) : base(repository)
    {

    }

    protected override async Task<IQueryable<IdentitySecurityLog>> CreateFilteredQueryAsync(SecurityLogGetListInput input)
    {
        input.TenantId = CurrentUser.TenantId;
        input.UserName = CurrentUser.UserName;
        return await base.CreateFilteredQueryAsync(input);
    }

    protected override async Task<IdentitySecurityLog> GetEntityByIdAsync(Guid id)
    {
        var entity = await base.GetEntityByIdAsync(id);

        //if (entity.UserId != CurrentUser.Id)
        if (entity.UserName != CurrentUser.UserName)
        {
            throw new EntityNotFoundException($"Not such entity by current user['{CurrentUser.Name}'],Entity id:{id}");
        }
        return entity;
    }

    protected override Task<PagedResultDto<KeyValueDto<TKeyType>>> GetListGroupByAsync<TKeyType>(SecurityLogGroupGetListInput input, string policyName, Expression<Func<IdentitySecurityLog, TKeyType>> keySelector)
    {
        input.UserName = CurrentUser.UserName;
        return base.GetListGroupByAsync(input, policyName, keySelector);
    }
}
