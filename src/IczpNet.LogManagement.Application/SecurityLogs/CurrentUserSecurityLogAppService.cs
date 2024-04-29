using IczpNet.LogManagement.SecurityLogs.Dtos;
using IczpNet.LogManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Repositories;
using IczpNet.LogManagement.BaseAppServices;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Auditing;

namespace IczpNet.LogManagement.SecurityLogs;

public class CurrentUserSecurityLogAppService : BaseGetListAppService<IdentitySecurityLog, SecurityLogDetailDto, SecurityLogDto, Guid, CurrentUserSecurityLogGetListInput>, ICurrentUserSecurityLogAppService
{
    protected override string GetListPolicyName { get; set; } = LogManagementPermissions.CurrentUserSecurityLogPermissions.GetList;
    protected override string GetPolicyName { get; set; } = LogManagementPermissions.CurrentUserSecurityLogPermissions.GetItem;

    public CurrentUserSecurityLogAppService(IRepository<IdentitySecurityLog, Guid> repository) : base(repository)
    {

    }

    protected override async Task<IQueryable<IdentitySecurityLog>> CreateFilteredQueryAsync(CurrentUserSecurityLogGetListInput input)
    {
        var query = (await base.CreateFilteredQueryAsync(input))
            .Where(x => x.TenantId == CurrentUser.TenantId)
            //.Where(x => x.UserId == CurrentUser.Id)
            .Where(x => x.UserName == CurrentUser.UserName)
            .WhereIf(!string.IsNullOrWhiteSpace(input.Identity), x => x.Identity == input.Identity)
            .WhereIf(!string.IsNullOrWhiteSpace(input.CorrelationId), x => x.CorrelationId == input.CorrelationId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ClientId), x => x.ClientId == input.ClientId)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ClientIpAddress), x => x.ClientIpAddress == input.ClientIpAddress)
            .WhereIf(!string.IsNullOrWhiteSpace(input.ApplicationName), x => x.ApplicationName == input.ApplicationName)
            .WhereIf(input.Actions != null && input.Actions.Count != 0, x => input.Actions!.Contains(x.Action))
            .WhereIf(input.StartCreationTime.HasValue, x => x.CreationTime > input.StartCreationTime)
            .WhereIf(input.EndCreationTime.HasValue, x => x.CreationTime <= input.EndCreationTime)
            .WhereIf(!string.IsNullOrWhiteSpace(input.BrowserInfo), x => x.BrowserInfo.Contains(input.BrowserInfo))
        ;

        return query;
    }

    protected override async Task<IdentitySecurityLog> GetEntityByIdAsync(Guid id)
    {
        var entity = await base.GetEntityByIdAsync(id);

        //if (entity.UserId != CurrentUser.Id)
        if (entity.UserName != CurrentUser.UserName)
        {
            throw new EntityNotFoundException($"Not such entity by current user['{CurrentUser.Name}'],Entity id:{id}");
        }
        return await base.GetEntityByIdAsync(id);
    }

    protected override IQueryable<IdentitySecurityLog> ApplyDefaultSorting(IQueryable<IdentitySecurityLog> query)
    {
        return query.OrderByDescending(x => x.CreationTime);
        //return base.ApplyDefaultSorting(query);
    }
}
