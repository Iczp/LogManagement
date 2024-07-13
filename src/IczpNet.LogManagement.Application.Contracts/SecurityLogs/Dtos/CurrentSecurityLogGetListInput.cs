using IczpNet.AbpCommons.Dtos;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IczpNet.LogManagement.SecurityLogs.Dtos;

public class CurrentSecurityLogGetListInput: SecurityLogGetListInput
{
    [JsonIgnore]
    public override Guid? UserId { get; set; }

    [JsonIgnore]
    public override string UserName { get; set; }
}
