using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace Notificator.Startup
{
    class BotSettings
    {
        public static ITelegramBotClient GetBotClient(IConfigurationRoot configuration)
        {
            var client = new TelegramBotClient(configuration["BOT_TOKEN"]!);
            return client;

        }
    }
}