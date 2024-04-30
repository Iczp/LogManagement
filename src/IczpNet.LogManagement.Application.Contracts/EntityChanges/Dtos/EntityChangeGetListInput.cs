using IczpNet.LogManagement.BaseDtos;
using System;
using System.Collections.Generic;
using Volo.Abp.Auditing;

namespace IczpNet.LogManagement.EntityChanges.Dtos;

public class EntityChangeGetListInput: GetListInput
{
    public virtual Guid? AuditLogId { get; set; }

    public virtual Guid? TenantId { get; set; }

    public virtual DateTime? StartChangeTime { get; set; }

    public virtual DateTime? EndChangeTime { get; set; }

    public virtual List<EntityChangeType> ChangeTypes { get; set; }

    public virtual Guid? EntityTenantId { get; set; }

    public virtual string EntityId { get; set; }

    public virtual string EntityTypeFullName { get; set; }
}
