using IczpNet.AbpCommons.Dtos;

namespace IczpNet.LogManagement.SecurityLogs.Dtos;

public class SecurityLogGroupGetListInput : GetListInput
{
    public string UserName { get; set; }
}
