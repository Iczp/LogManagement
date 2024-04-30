using IczpNet.LogManagement.EntityPropertyChanges.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace IczpNet.LogManagement.EntityPropertyChanges;

public interface IEntityPropertyChangeAppService : IReadOnlyAppService<EntityPropertyChangeDetailDto, EntityPropertyChangeDto, Guid, EntityPropertyChangeGetListInput>
{

}
