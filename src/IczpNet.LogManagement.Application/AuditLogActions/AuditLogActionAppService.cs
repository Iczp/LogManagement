using IczpNet.LogManagement.AuditLogActions.Dtos;
using IczpNet.LogManagement.BaseAppServices;
using IczpNet.AbpCommons.Dtos;
using IczpNet.LogManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace IczpNet.LogManagement.AuditLogActions;

public class AuditLogActionAppService : BaseGetListAppService<AuditLogAction, AuditLogActionDetailDto, AuditLogActionDto, Guid, AuditLogActionGetListInput>, IAuditLogActionAppService
{

    protected override string GetListPolicyName { get; set; } = LogManagementPermissions.AuditLogActionPermissions.GetList;
    protected override string GetPolicyName { get; set; } = LogManagementPermissions.AuditLogActionPermissions.GetItem;
    protected virtual string GroupByServiceNamePolicyName { get; set; } = LogManagementPermissions.AuditLogActionPermissions.GroupByServiceName;
    protected IAuditingManager AuditingManager { get; }
    protected IAuditingStore AuditingStore { get; }

    public AuditLogActionAppService(IRepository<AuditLogAction, Guid> repository) : base(repository)
    {
    }

    //[HttpGet]
    protected override async Task<IQueryable<AuditLogAction>> CreateFilteredQueryAsync(AuditLogActionGetListInput input)
    {
        var query = (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.AuditLogId.HasValue, x => x.AuditLogId == input.AuditLogId)
            .WhereIf(input.TenantId.HasValue, x => x.TenantId == input.TenantId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ServiceName), x => x.ServiceName == input.ServiceName)
            .WhereIf(!string.IsNullOrWhiteSpace(input.MethodName), x => x.MethodName == input.MethodName)
            .WhereIf(input.MinExecutionDuration.HasValue, x => x.ExecutionDuration > input.MinExecutionDuration)
            .WhereIf(input.MaxExecutionDuration.HasValue, x => x.ExecutionDuration <= input.MaxExecutionDuration)
            .WhereIf(input.StartExecutionTime.HasValue, x => x.ExecutionTime >= input.StartExecutionTime)
            .WhereIf(input.EndExecutionTime.HasValue, x => x.ExecutionTime < input.EndExecutionTime)
        ;

        return query;
    }

    protected override IQueryable<AuditLogAction> ApplyDefaultSorting(IQueryable<AuditLogAction> query)
    {
        return query.OrderByDescending(x => x.ExecutionTime);
    }

    /// <summary>
    /// ServiceName 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public virtual async Task<PagedResultDto<KeyValueDto<string>>> GetListApplicationNamesAsync(GetListInput input)
    {
        return await GetEntityGroupListAsync(
            x => x,
            input, GroupByServiceNamePolicyName, x => x.ServiceName);
    }

}
