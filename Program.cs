using System;
using Microsoft.Extensions.Configuration;
using Notificator.Startup;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Notificator
{
    class Program
    {
        static IConfigurationRoot? _config;
        static ITelegramBotClient? _client;
        async static Task Main(string[] args)
        {
            _config = ConfigurationSettings.GetConfiguration();
            _client = BotSettings.GetBotClient(_config);

            using var cts = new CancellationTokenSource();

            _client.StartReceiving(UpdateHandler, async (bot, ex, ct) => Console.WriteLine(ex), cancellationToken: cts.Token);

            var me = await _client.GetMeAsync();
            Console.WriteLine($"{me.FirstName} запущен!");
            await Task.Delay(-1);
        }

        private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            System.Console.WriteLine(update.Message.Chat.Id);

        }

    }


}