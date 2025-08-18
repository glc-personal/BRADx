namespace Configurations.Providers;

public interface IAppSettingsConfigProvider
{
    Task<IDictionary<string, IControllerConfig>> GetConfigsAsync(AppSettingsConfigFilesOptions options, CancellationToken cancellationToken = default);
}