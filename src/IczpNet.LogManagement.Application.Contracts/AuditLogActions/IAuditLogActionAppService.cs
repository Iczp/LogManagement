using IczpNet.LogManagement.AuditLogActions.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace IczpNet.LogManagement.AuditLogActions;

public interface IAuditLogActionAppService : IReadOnlyAppService<AuditLogActionDetailDto, AuditLogActionDto, Guid, AuditLogActionGetListInput>
{

}
