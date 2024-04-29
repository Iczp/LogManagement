using IczpNet.LogManagement.BaseDtos;
using System;
using System.Collections.Generic;

namespace IczpNet.LogManagement.SecurityLogs.Dtos;

public class SecurityLogGetListInput: GetListInput
{
    public Guid? TenantId { get; set; }

    public string ApplicationName { get; set; }

    public string Identity { get; set; }

    public List<string> Actions { get; set; }

    public Guid? UserId { get; set; }

    public string UserName { get; set; }

    public string TenantName { get; set; }

    public string ClientId { get; set; }

    public string CorrelationId { get; set; }

    public string ClientIpAddress { get; set; }

    public string BrowserInfo { get; set; }

    //public DateTime CreationTime { get; set; }

    public virtual DateTime? StartCreationTime { get; set; }

    public virtual DateTime? EndCreationTime { get; set; }
}
