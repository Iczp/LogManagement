using Volo.Abp.Data;

namespace IczpNet.LogManagement.EntityChanges.Dtos;

public class EntityChangeDetailDto : EntityChangeDto, IHasExtraProperties
{
    //public virtual ICollection<EntityPropertyChangeDto> PropertyChanges { get; set; }

    public virtual ExtraPropertyDictionary ExtraProperties { get; set; }
}
