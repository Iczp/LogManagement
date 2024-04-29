using IczpNet.LogManagement.SecurityLogs.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace IczpNet.LogManagement.SecurityLogs;

public interface ISecurityLogAppService : IReadOnlyAppService<SecurityLogDetailDto, SecurityLogDto, Guid, SecurityLogGetListInput>
{

}
