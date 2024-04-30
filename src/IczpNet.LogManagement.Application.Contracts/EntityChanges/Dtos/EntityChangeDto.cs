using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace IczpNet.LogManagement.EntityChanges.Dtos;

public class EntityChangeDto : EntityDto<Guid>
{
    public virtual Guid AuditLogId { get; set; }

    public virtual Guid? TenantId { get; set; }

    public virtual DateTime ChangeTime { get; set; }

    public virtual EntityChangeType ChangeType { get; set; }

    public virtual Guid? EntityTenantId { get; set; }

    public virtual string EntityId { get; set; }

    public virtual string EntityTypeFullName { get; set; }

}
