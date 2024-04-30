using AutoMapper;
using IczpNet.LogManagement.AuditLogActions.Dtos;
using IczpNet.LogManagement.AuditLogs.Dtos;
using IczpNet.LogManagement.EntityChanges.Dtos;
using IczpNet.LogManagement.EntityPropertyChanges.Dtos;
using IczpNet.LogManagement.SecurityLogs.Dtos;
using Volo.Abp.AuditLogging;
using Volo.Abp.Identity;

namespace IczpNet.LogManagement.AutoMappers;

public class LogManagementApplicationAutoMapperProfile : Profile
{
    public LogManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        //AuditLog
        CreateMap<AuditLog, AuditLogDto>();
        CreateMap<AuditLog, AuditLogDetailDto>()
            .MapExtraProperties();

        //AuditLogAction
        CreateMap<AuditLogAction, AuditLogActionDto>();
        CreateMap<AuditLogAction, AuditLogActionDetailDto>()
            .MapExtraProperties();

        //EntityChange
        CreateMap<EntityChange, EntityChangeDto>();
        CreateMap<EntityChange, EntityChangeDetailDto>().MapExtraProperties();

        //EntityPropertyChange
        CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();
        CreateMap<EntityPropertyChange, EntityPropertyChangeDetailDto>();

        //SecurityLog
        CreateMap<IdentitySecurityLog, SecurityLogDto>();
        CreateMap<IdentitySecurityLog, SecurityLogDetailDto>()
            .MapExtraProperties();
    }
}
