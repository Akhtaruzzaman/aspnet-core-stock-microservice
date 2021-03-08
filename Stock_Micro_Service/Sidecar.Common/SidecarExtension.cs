using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sidecar.Common
{
    public static class SidecarExtension
    {
        public static IWebHostBuilder UseKVConfiguration(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.ConfigureServices(services => {
                IConfigurationRoot configuration = LoadKeyVaultSettings();
                services.AddSingleton<IConfiguration>(configuration);
            });

            return webHostBuilder;
        }

        private static IConfigurationRoot LoadKeyVaultSettings()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true)
               .AddEnvironmentVariables()
               .Build();

            var sc = new ServiceConfiguration();
            configuration.Bind(sc);

            var configBuilder = new ConfigurationBuilder();
            if (sc.KeyVault != null && !string.IsNullOrEmpty(sc.KeyVault.Uri))
            {
                if (!string.IsNullOrEmpty(sc.KeyVault.ClientId) && !string.IsNullOrEmpty(sc.KeyVault.Secret))
                {
                    configBuilder.AddAzureKeyVault(sc.KeyVault.Uri, sc.KeyVault.ClientId, sc.KeyVault.Secret);
                }
            }

            return configBuilder
               .AddJsonFile("appsettings.json", optional: true)
               .AddEnvironmentVariables()
               .Build();
        }
        public class ServiceConfiguration
        {
            public KeyVaultInfo KeyVault { get; set; }
        }
        public class KeyVaultInfo
        {
            public string Uri { get; set; }

            public string ClientId { get; set; }

            public string Secret { get; set; }
        }
    }
}
