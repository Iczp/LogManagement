using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace IczpNet.LogManagement.MongoDB;

[ConnectionStringName(LogManagementDbProperties.ConnectionStringName)]
public class LogManagementMongoDbContext : AbpMongoDbContext, ILogManagementMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureLogManagement();
    }
}
