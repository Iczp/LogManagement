using IczpNet.LogManagement.BaseDtos;
using System;

namespace IczpNet.LogManagement.EntityPropertyChanges.Dtos;

public class EntityPropertyChangeGetListInput: GetListInput
{
    public virtual Guid? TenantId { get; set; }

    public virtual Guid? EntityChangeId { get; set; }

    public virtual string NewValue { get; set; }

    public virtual string OriginalValue { get; set; }

    public virtual string PropertyName { get; set; }

    public virtual string PropertyTypeFullName { get; set; }
}
