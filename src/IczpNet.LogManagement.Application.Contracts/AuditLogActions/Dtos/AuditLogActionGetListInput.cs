using IczpNet.LogManagement.BaseDtos;
using System;

namespace IczpNet.LogManagement.AuditLogActions.Dtos;

public class AuditLogActionGetListInput: GetListInput
{
    public virtual Guid? TenantId { get; set; }

    public virtual Guid? AuditLogId { get; set; }

    public virtual string ServiceName { get; set; }

    public virtual string MethodName { get; set; }

    public virtual DateTime? StartExecutionTime { get; set; } = DateTime.Now.AddDays(-30);

    public virtual DateTime? EndExecutionTime { get; set; }

    public virtual int? MinExecutionDuration { get; set; }

    public virtual int? MaxExecutionDuration { get; set; }
}
