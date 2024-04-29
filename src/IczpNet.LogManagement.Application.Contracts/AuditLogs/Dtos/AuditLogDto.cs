using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace IczpNet.LogManagement.AuditLogs.Dtos;

public class AuditLogDto : EntityDto<Guid>
{
    public virtual string ApplicationName { get; set; }

    public virtual Guid? UserId { get; set; }

    public virtual string UserName { get; set; }

    public virtual Guid? TenantId { get; set; }

    public virtual string TenantName { get; set; }

    public virtual DateTime ExecutionTime { get; set; }

    public virtual int ExecutionDuration { get; set; }

    public virtual string ClientIpAddress { get; set; }

    public virtual string ClientName { get; set; }

    public virtual string ClientId { get; set; }

    public virtual string BrowserInfo { get; set; }

    public virtual string HttpMethod { get; set; }

    public virtual string Url { get; set; }

    public virtual int? HttpStatusCode { get; set; }
}
