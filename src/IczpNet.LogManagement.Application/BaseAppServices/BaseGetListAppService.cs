using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using IczpNet.LogManagement.Localization;
using System.Threading.Tasks;


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
}
