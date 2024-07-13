using IczpNet.LogManagement.AuditLogs.Dtos;
using IczpNet.LogManagement.BaseAppServices;
using IczpNet.AbpCommons.Dtos;
using IczpNet.LogManagement.Permissions;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AuditLogging;

namespace IczpNet.LogManagement.AuditLogs;

public class AuditLogAppService : BaseGetListAppService<AuditLog, AuditLogDetailDto, AuditLogDto, Guid, AuditLogGetListInput>, IAuditLogAppService
{
    protected override string GetListPolicyName { get; set; } = LogManagementPermissions.AuditLogPermissions.GetList;
    protected override string GetPolicyName { get; set; } = LogManagementPermissions.AuditLogPermissions.GetItem;
    protected virtual string GroupByClientIdPolicyName { get; set; } = LogManagementPermissions.AuditLogPermissions.GroupByClientId;
    protected virtual string GroupByApplicationNamePolicyName { get; set; } = LogManagementPermissions.AuditLogPermissions.GroupByApplicationName;
    protected virtual string GroupByHttpMethodPolicyName { get; set; } = LogManagementPermissions.AuditLogPermissions.GroupByHttpMethod;
    protected virtual string GroupByHttpStatusCodePolicyName { get; set; } = LogManagementPermissions.AuditLogPermissions.GroupByHttpStatusCode;

    public AuditLogAppService(IAuditLogRepository repository) : base(repository)
    {
    }

    //[HttpGet]
    protected override async Task<IQueryable<AuditLog>> CreateFilteredQueryAsync(AuditLogGetListInput input)
    {
        var query = (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.UserId.HasValue, x => x.UserId == input.UserId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.UserName), x => x.UserName == input.UserName)
            .WhereIf(input.TenantId.HasValue, x => x.TenantId == input.TenantId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.TenantName), x => x.TenantName == input.TenantName)
            .WhereIf(input.ImpersonatorTenantId.HasValue, x => x.ImpersonatorTenantId == input.ImpersonatorTenantId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ImpersonatorTenantName), x => x.ImpersonatorTenantName == input.ImpersonatorTenantName)
            .WhereIf(input.ImpersonatorUserId.HasValue, x => x.ImpersonatorUserId == input.ImpersonatorUserId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ImpersonatorUserName), x => x.ImpersonatorUserName == input.ImpersonatorUserName)
            .WhereIf(!string.IsNullOrWhiteSpace(input.CorrelationId), x => x.CorrelationId == input.CorrelationId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ClientId), x => x.ClientId == input.ClientId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ClientName), x => x.ClientName == input.ClientName)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ClientIpAddress), x => x.ClientIpAddress == input.ClientIpAddress)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ApplicationName), x => x.ApplicationName == input.ApplicationName)
            .WhereIf(!string.IsNullOrWhiteSpace(input.Url), x => x.Url.StartsWith(input.Url))
            .WhereIf(input.HttpMethods != null && input.HttpMethods.Count != 0, x => input.HttpMethods!.Contains(x.HttpMethod))
            .WhereIf(input.HttpStatusCodes != null && input.HttpStatusCodes.Count != 0, x => input.HttpStatusCodes!.Contains(x.HttpStatusCode))

            .WhereIf(input.MinExecutionDuration.HasValue, x => x.ExecutionDuration > input.MinExecutionDuration)
            .WhereIf(input.MaxExecutionDuration.HasValue, x => x.ExecutionDuration <= input.MaxExecutionDuration)

            .WhereIf(input.StartExecutionTime.HasValue, x => x.ExecutionTime >= input.StartExecutionTime)
            .WhereIf(input.EndExecutionTime.HasValue, x => x.ExecutionTime < input.EndExecutionTime)

            .WhereIf(!string.IsNullOrWhiteSpace(input.Comments), x => x.Comments.Contains(input.Comments))
            .WhereIf(!string.IsNullOrWhiteSpace(input.BrowserInfo), x => x.BrowserInfo.Contains(input.BrowserInfo))
        ;

        return query;
    }

    protected override IQueryable<AuditLog> ApplyDefaultSorting(IQueryable<AuditLog> query)
    {
        return query.OrderByDescending(x => x.ExecutionTime);
    }

    /// <summary>
    /// ApplicationName 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public virtual async Task<PagedResultDto<KeyValueDto<string>>> GetListApplicationNamesAsync(GetListInput input)
    {
        return await GetEntityGroupListAsync(
            x => x,
            input, GroupByApplicationNamePolicyName, x => x.ApplicationName);
    }

    /// <summary>
    /// ClientId 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public virtual async Task<PagedResultDto<KeyValueDto<string>>> GetListClientIdsAsync(GetListInput input)
    {
        return await GetEntityGroupListAsync(
            x => x,
            input, GroupByClientIdPolicyName, x => x.ClientId);
    }

    /// <summary>
    /// HttpMethod 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public virtual async Task<PagedResultDto<KeyValueDto<string>>> GetListHttpMethodsAsync(GetListInput input)
    {
        return await GetEntityGroupListAsync(
            x => x,
            input, GroupByHttpMethodPolicyName, x => x.HttpMethod);
    }

    /// <summary>
    /// HttpStatusCode 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public virtual async Task<PagedResultDto<KeyValueDto<int?>>> GetListHttpStatusCodesAsync(GetListInput input)
    {
        return await GetEntityGroupListAsync(
            x => x,
            input, GroupByHttpStatusCodePolicyName, x => x.HttpStatusCode);
    }
}
