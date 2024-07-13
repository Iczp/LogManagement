using IczpNet.AbpCommons.Dtos;
using System;
using System.Collections.Generic;

namespace IczpNet.LogManagement.SecurityLogs.Dtos;

public  class SecurityLogGetListInput: GetListInput
{
    public virtual Guid? TenantId { get; set; }

    public virtual string ApplicationName { get; set; }

    public virtual string Identity { get; set; }

    public virtual List<string> Actions { get; set; }

    public virtual Guid? UserId { get; set; }

    public virtual string UserName { get; set; }

    public virtual string TenantName { get; set; }

    public virtual string ClientId { get; set; }

    public virtual string CorrelationId { get; set; }

    public virtual string ClientIpAddress { get; set; }

    public virtual string BrowserInfo { get; set; }

    //public virtual DateTime CreationTime { get; set; }

    public virtual DateTime? StartCreationTime { get; set; }

    public virtual DateTime? EndCreationTime { get; set; }
}
