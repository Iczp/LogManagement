using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace IczpNet.LogManagement.MongoDB;

[ConnectionStringName(LogManagementDbProperties.ConnectionStringName)]
public interface ILogManagementMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
