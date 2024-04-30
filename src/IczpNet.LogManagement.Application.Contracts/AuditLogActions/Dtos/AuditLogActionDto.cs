using System;
using Volo.Abp.Application.Dtos;

namespace IczpNet.LogManagement.AuditLogActions.Dtos;

public class AuditLogActionDto : EntityDto<Guid>
{
    public virtual Guid? TenantId { get; set; }

    public virtual Guid AuditLogId { get; set; }

    public virtual string ServiceName { get; set; }

    public virtual string MethodName { get; set; }

    public virtual DateTime ExecutionTime { get; set; }

    public virtual int ExecutionDuration { get; set; }

}
