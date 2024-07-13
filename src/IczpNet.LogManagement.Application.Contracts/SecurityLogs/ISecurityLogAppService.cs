using IczpNet.AbpCommons.Dtos;
using IczpNet.LogManagement.SecurityLogs.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace IczpNet.LogManagement.SecurityLogs;

public interface ISecurityLogAppService : IReadOnlyAppService<SecurityLogDetailDto, SecurityLogDto, Guid, SecurityLogGetListInput>
{
    /// <summary>
    /// Actions 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedResultDto<KeyValueDto<string>>> GetListActionsAsync(SecurityLogGroupGetListInput input);

    /// <summary>
    /// ApplicationName 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedResultDto<KeyValueDto<string>>> GetListApplicationNamesAsync(SecurityLogGroupGetListInput input);

    /// <summary>
    /// ClientId 列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedResultDto<KeyValueDto<string>>> GetListClientIdsAsync(SecurityLogGroupGetListInput input);
}
