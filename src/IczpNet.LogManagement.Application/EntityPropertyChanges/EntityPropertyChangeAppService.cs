using IczpNet.LogManagement.EntityPropertyChanges.Dtos;
using IczpNet.LogManagement.BaseAppServices;
using IczpNet.LogManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace IczpNet.LogManagement.EntityPropertyChanges;

/// <summary>
/// 实体属性变更
/// </summary>
public class EntityPropertyChangeAppService : BaseGetListAppService<EntityPropertyChange, EntityPropertyChangeDetailDto, EntityPropertyChangeDto, Guid, EntityPropertyChangeGetListInput>, IEntityPropertyChangeAppService
{

    protected override string GetListPolicyName { get; set; } = LogManagementPermissions.EntityPropertyChangePermissions.GetList;
    protected override string GetPolicyName { get; set; } = LogManagementPermissions.EntityPropertyChangePermissions.GetItem;

    public EntityPropertyChangeAppService(IRepository<EntityPropertyChange, Guid> repository) : base(repository)
    {
    }

    //[HttpGet]
    protected override async Task<IQueryable<EntityPropertyChange>> CreateFilteredQueryAsync(EntityPropertyChangeGetListInput input)
    {
        var query = (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.EntityChangeId.HasValue, x => x.EntityChangeId == input.EntityChangeId)
            .WhereIf(input.TenantId.HasValue, x => x.TenantId == input.TenantId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.NewValue), x => x.NewValue == input.NewValue)
            .WhereIf(!string.IsNullOrWhiteSpace(input.OriginalValue), x => x.OriginalValue == input.OriginalValue)
            .WhereIf(!string.IsNullOrWhiteSpace(input.PropertyName), x => x.PropertyName == input.PropertyName)
            .WhereIf(!string.IsNullOrWhiteSpace(input.PropertyTypeFullName), x => x.PropertyTypeFullName == input.PropertyTypeFullName)
            .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.NewValue.Contains(input.Keyword))
        ;

        return query;
    }

    protected override IQueryable<EntityPropertyChange> ApplyDefaultSorting(IQueryable<EntityPropertyChange> query)
    {
        return query;
    }
}
