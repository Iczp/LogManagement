using Volo.Abp;
using Volo.Abp.MongoDB;

namespace IczpNet.LogManagement.MongoDB;

public static class LogManagementMongoDbContextExtensions
{
    public static void ConfigureLogManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
