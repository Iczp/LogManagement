using System;
using Volo.Abp.Data;

namespace IczpNet.LogManagement.AuditLogs.Dtos;

public class AuditLogDetailDto : AuditLogDto, IHasExtraProperties
{
    public virtual Guid? ImpersonatorUserId { get; set; }

    public virtual string ImpersonatorUserName { get; set; }

    public virtual Guid? ImpersonatorTenantId { get; set; }

    public virtual string ImpersonatorTenantName { get; set; }

    public virtual string CorrelationId { get; set; }

    public virtual string Comments { get; set; }

    public virtual string Exceptions { get; set; }

    public ExtraPropertyDictionary ExtraProperties { get; set; }
}
