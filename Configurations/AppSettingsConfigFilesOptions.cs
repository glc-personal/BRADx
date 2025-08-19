namespace Configurations;

public sealed class AppSettingsConfigFilesOptions
{
    public required string Directory { get; set; } = "/apps/configs";
    public required string Prefix { get; set; }
    public required string Postfix { get; set; } 
}