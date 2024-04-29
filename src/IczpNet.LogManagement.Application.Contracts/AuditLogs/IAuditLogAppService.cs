using IczpNet.LogManagement.AuditLogs.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace IczpNet.LogManagement.AuditLogs;

public interface IAuditLogAppService : IReadOnlyAppService<AuditLogDetailDto, AuditLogDto, Guid, AuditLogGetListInput>
{

}
