using IczpNet.LogManagement.BaseDtos;
using System;
using System.Collections.Generic;

namespace IczpNet.LogManagement.SecurityLogs.Dtos;

public class CurrentUserSecurityLogGetListInput : GetListInput
{

    public string ApplicationName { get; set; }

    public string Identity { get; set; }

    public List<string> Actions { get; set; }

    public string ClientId { get; set; }

    public string CorrelationId { get; set; }

    public string ClientIpAddress { get; set; }

    public string BrowserInfo { get; set; }

    //public DateTime CreationTime { get; set; }

    public virtual DateTime? StartCreationTime { get; set; }

    public virtual DateTime? EndCreationTime { get; set; }
}
