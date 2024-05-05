using IczpNet.LogManagement.BaseDtos;

namespace IczpNet.LogManagement.SecurityLogs.Dtos;

public class SecurityLogActionGetListInput : GetListInput
{
    public string UserName { get; set; }
}
