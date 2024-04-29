using System;
using Volo.Abp.Data;

namespace IczpNet.LogManagement.SecurityLogs.Dtos;

public class SecurityLogDetailDto : SecurityLogDto, IHasExtraProperties
{

    public ExtraPropertyDictionary ExtraProperties { get; set; }
}
