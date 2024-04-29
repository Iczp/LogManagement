using IczpNet.LogManagement.SecurityLogs.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace IczpNet.LogManagement.SecurityLogs;

public interface ICurrentUserSecurityLogAppService : IReadOnlyAppService<SecurityLogDetailDto, SecurityLogDto, Guid, CurrentUserSecurityLogGetListInput>
{

}
