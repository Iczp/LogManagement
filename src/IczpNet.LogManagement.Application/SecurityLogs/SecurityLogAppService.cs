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

namespace IczpNet.LogManagement.SecurityLogs;

/// <summary>
/// 用户安全日志
/// </summary>
public class SecurityLogAppService : BaseGetListAppService<IdentitySecurityLog, SecurityLogDetailDto, SecurityLogDto, Guid, SecurityLogGetListInput>, ISecurityLogAppService
{
    protected override string GetListPolicyName { get; set; } = LogManagementPermissions.SecurityLogPermissions.GetList;
    protected override string GetPolicyName { get; set; } = LogManagementPermissions.SecurityLogPermissions.GetItem;
    protected virtual string GroupByActionPolicyName { get; set; } = LogManagementPermissions.SecurityLogPermissions.GroupByActionPolicyName;
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

    public virtual async Task<PagedResultDto<KeyValueDto>> GetListActionsAsync(SecurityLogActionGetListInput input)
    {
        await CheckPolicyAsync(GroupByActionPolicyName);

        var countQuery = (await Repository.GetQueryableAsync())
            .WhereIf(!string.IsNullOrWhiteSpace(input.UserName), x => x.UserName == input.UserName)
            .GroupBy(x => x.Action)
            .Select(x => new KeyValueDto()
            {
                Key = x.Key,
                Count = x.Count()
            })
            ;

        return await GetPagedListAsync<KeyValueDto>(countQuery, input);
    }
}
