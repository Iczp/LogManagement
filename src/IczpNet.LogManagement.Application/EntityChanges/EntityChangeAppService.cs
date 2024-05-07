using IczpNet.LogManagement.EntityChanges.Dtos;
using IczpNet.LogManagement.BaseAppServices;
using IczpNet.LogManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace IczpNet.LogManagement.EntityChanges;

/// <summary>
/// 实体变更
/// </summary>
public class EntityChangeAppService : BaseGetListAppService<EntityChange, EntityChangeDetailDto, EntityChangeDto, Guid, EntityChangeGetListInput>, IEntityChangeAppService
{

    protected override string GetListPolicyName { get; set; } = LogManagementPermissions.EntityChangePermissions.GetList;
    protected override string GetPolicyName { get; set; } = LogManagementPermissions.EntityChangePermissions.GetItem;

    public EntityChangeAppService(IRepository<EntityChange, Guid> repository) : base(repository)
    {
    }

    //[HttpGet]
    protected override async Task<IQueryable<EntityChange>> CreateFilteredQueryAsync(EntityChangeGetListInput input)
    {
        var query = (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.AuditLogId.HasValue, x => x.AuditLogId == input.AuditLogId)
            .WhereIf(input.TenantId.HasValue, x => x.TenantId == input.TenantId)
            .WhereIf(input.EntityTenantId.HasValue, x => x.EntityTenantId == input.EntityTenantId)
            .WhereIf(input.ChangeTypes != null && input.ChangeTypes.Count != 0, x => input.ChangeTypes!.Contains(x.ChangeType))
            .WhereIf(!string.IsNullOrWhiteSpace(input.EntityId), x => x.EntityId == input.EntityId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.EntityTypeFullName), x => x.EntityTypeFullName == input.EntityTypeFullName)
            .WhereIf(input.StartChangeTime.HasValue, x => x.ChangeTime >= input.StartChangeTime)
            .WhereIf(input.EndChangeTime.HasValue, x => x.ChangeTime < input.EndChangeTime)
            .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.EntityTypeFullName.Contains(input.Keyword))
        ;
        return query;
    }

    protected override IQueryable<EntityChange> ApplyDefaultSorting(IQueryable<EntityChange> query)
    {
        return query;
    }
}
