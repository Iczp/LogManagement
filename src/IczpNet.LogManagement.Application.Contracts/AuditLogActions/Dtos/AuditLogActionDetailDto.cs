using System;
using Volo.Abp.Data;

namespace IczpNet.LogManagement.AuditLogActions.Dtos;

public class AuditLogActionDetailDto : AuditLogActionDto, IHasExtraProperties
{
    public virtual string Parameters { get; set; }

    public virtual ExtraPropertyDictionary ExtraProperties { get; set; }
}
