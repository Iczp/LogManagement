using System;
using Volo.Abp.Application.Dtos;

namespace IczpNet.LogManagement.EntityPropertyChanges.Dtos;

public class EntityPropertyChangeDto : EntityDto<Guid>
{
    public virtual Guid? TenantId { get; set; }

    public virtual Guid EntityChangeId { get; set; }

    public virtual string NewValue { get; set; }

    public virtual string OriginalValue { get; set; }

    public virtual string PropertyName { get; set; }

    public virtual string PropertyTypeFullName { get; set; }

}
