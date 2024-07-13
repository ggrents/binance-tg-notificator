using Microsoft.Extensions.Configuration;

namespace Notificator.Startup
{
    class ConfigurationSettings
    {
        public static IConfigurationRoot GetConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true);

            return builder.Build();
        }
    }
}