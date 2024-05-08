using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using IczpNet.LogManagement.Localization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using IczpNet.AbpCommons.Extensions;
using IczpNet.LogManagement.BaseDtos;
using System.Linq.Expressions;


namespace IczpNet.LogManagement.BaseAppServices;

public abstract class BaseGetListAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput>
    //:CrudAppService
    : AbstractKeyReadOnlyAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput>
    where TEntity : class, IEntity<TKey>
    where TGetOutputDto : IEntityDto<TKey>
    where TGetListOutputDto : IEntityDto<TKey>
{
    protected IRepository<TEntity, TKey> Repository { get; }
    protected BaseGetListAppService(IRepository<TEntity, TKey> repository) : base(repository)
    {
        Repository = repository;
        LocalizationResource = typeof(LogManagementResource);
        ObjectMapperContext = typeof(LogManagementApplicationModule);
    }

    protected override Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        return Repository.GetAsync(id);
    }

    protected virtual async Task<PagedResultDto<TOuputDto>> GetPagedListAsync<T, TOuputDto>(
        IQueryable<T> query,
        PagedAndSortedResultRequestDto input,
        Func<IQueryable<T>, IQueryable<T>>? queryableAction = null,
        Func<List<T>, Task<List<T>>>? entityAction = null)
    {
        return await query.ToPagedListAsync<T, TOuputDto>(AsyncExecuter, ObjectMapper, input, queryableAction, entityAction);
    }
    protected virtual async Task<PagedResultDto<T>> GetPagedListAsync<T>(
        IQueryable<T> query,
        PagedAndSortedResultRequestDto input,
        Func<IQueryable<T>, IQueryable<T>>? queryableAction = null,
        Func<List<T>, Task<List<T>>>? entityAction = null)
    {
        return await GetPagedListAsync<T, T>(query, input, queryableAction, entityAction);
    }

    protected virtual async Task<PagedResultDto<KeyValueDto<TType>>> GetEntityGroupListAsync<TType>(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryable, GetListInput input, string policyName, Expression<Func<TEntity, TType>> keySelector)
    {
        await CheckPolicyAsync(policyName);

        var query = queryable((await Repository.GetQueryableAsync()))
            .GroupBy(keySelector)
            .Select(x => new KeyValueDto<TType>()
            {
                Key = x.Key,
                Count = x.Count()
            })
            ;

        return await GetPagedListAsync<KeyValueDto<TType>>(query, input);
    }
}
