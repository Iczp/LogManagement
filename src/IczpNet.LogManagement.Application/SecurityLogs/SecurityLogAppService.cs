using IczpNet.LogManagement.SecurityLogs.Dtos;
using IczpNet.LogManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Repositories;
using IczpNet.LogManagement.BaseAppServices;
using Volo.Abp.Application.Dtos;
using IczpNet.LogManagement.BaseDtos;
using System.Linq.Expressions;

namespace IczpNet.LogManagement.SecurityLogs;

/// <summary>
/// 用户安全日志
/// </summary>
public class SecurityLogAppService : BaseGetListAppService<IdentitySecurityLog, SecurityLogDetailDto, SecurityLogDto, Guid, SecurityLogGetListInput>, ISecurityLogAppService
{
    protected override string GetListPolicyName { get; set; } = LogManagementPermissions.SecurityLogPermissions.GetList;
    protected override string GetPolicyName { get; set; } = LogManagementPermissions.SecurityLogPermissions.GetItem;
    protected virtual string GroupByActionPolicyName { get; set; } = LogManagementPermissions.SecurityLogPermissions.GroupByAction;
    protected virtual string GroupByApplicationNamePolicyName { get; set; } = LogManagementPermissions.SecurityLogPermissions.GroupByApplicationName;
    protected virtual string GroupByClientIdPolicyName { get; set; } = LogManagementPermissions.SecurityLogPermissions.GroupByClientId;

    public SecurityLogAppService(IRepository<IdentitySecurityLog, Guid> repository) : base(repository)
    {

    }

    protected override async Task<IQueryable<IdentitySecurityLog>> CreateFilteredQueryAsync(SecurityLogGetListInput input)
    {
        var query = (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!string.IsNullOrWhiteSpace(input.Identity), x => x.Identity == input.Identity)
            .WhereIf(input.UserId.HasValue, x => x.UserId == input.UserId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.UserName), x => x.UserName == input.UserName)
            .WhereIf(input.TenantId.HasValue, x => x.TenantId == input.TenantId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.TenantName), x => x.TenantName == input.TenantName)
            .WhereIf(!string.IsNullOrWhiteSpace(input.CorrelationId), x => x.CorrelationId == input.CorrelationId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ClientId), x => x.ClientId == input.ClientId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ClientIpAddress), x => x.ClientIpAddress == input.ClientIpAddress)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ApplicationName), x => x.ApplicationName == input.ApplicationName)
            .WhereIf(input.Actions != null && input.Actions.Count != 0, x => input.Actions!.Contains(x.Action))
            .WhereIf(input.StartCreationTime.HasValue, x => x.CreationTime >= input.StartCreationTime)
            .WhereIf(input.EndCreationTime.HasValue, x => x.CreationTime < input.EndCreationTime)
            .WhereIf(!string.IsNullOrWhiteSpace(input.BrowserInfo), x => x.BrowserInfo.Contains(input.BrowserInfo))
        ;

        return query;
    }

    protected override IQueryable<IdentitySecurityLog> ApplyDefaultSorting(IQueryable<IdentitySecurityLog> query)
    {
        return query.OrderByDescending(x => x.CreationTime);
    }

    protected virtual async Task<PagedResultDto<KeyValueDto<TKeyType>>> GetListGroupByAsync<TKeyType>(SecurityLogGroupGetListInput input, string policyName, Expression<Func<IdentitySecurityLog, TKeyType>> keySelector)
    {
        return await GetEntityGroupListAsync(
            x => x.WhereIf(!string.IsNullOrWhiteSpace(input.UserName), x => x.UserName == input.UserName),
            input, policyName, keySelector);
    }

    /// <summary>
    /// Actions 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public virtual async Task<PagedResultDto<KeyValueDto<string>>> GetListActionsAsync(SecurityLogGroupGetListInput input)
    {
        return await GetListGroupByAsync(input, GroupByActionPolicyName, x => x.Action);
    }

    /// <summary>
    /// ApplicationName 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public virtual async Task<PagedResultDto<KeyValueDto<string>>> GetListApplicationNamesAsync(SecurityLogGroupGetListInput input)
    {
        return await GetListGroupByAsync(input, GroupByApplicationNamePolicyName, x => x.ApplicationName);
    }

    /// <summary>
    /// ClientId 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public virtual async Task<PagedResultDto<KeyValueDto<string>>> GetListClientIdsAsync(SecurityLogGroupGetListInput input)
    {
        return await GetListGroupByAsync(input, GroupByClientIdPolicyName, x => x.ClientId);
    }

}
