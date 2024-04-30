using IczpNet.LogManagement.EntityChanges.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace IczpNet.LogManagement.EntityChanges;

public interface IEntityChangeAppService : IReadOnlyAppService<EntityChangeDetailDto, EntityChangeDto, Guid, EntityChangeGetListInput>
{

}
