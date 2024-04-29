namespace IczpNet.LogManagement;

public static class LogManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "LogManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "LogManagement";
}
