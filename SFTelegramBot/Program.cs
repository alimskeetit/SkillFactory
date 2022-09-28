using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using SFTelegramBot.Controllers;
using SFTelegramBot.Services;
using SFTelegramBot.Configuration;

namespace SFTelegramBot
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                ConfigureServices(services)).UseConsoleLifetime().Build();

            Console.WriteLine("Сервис запущен");

            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            //подключаем контроллеры
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();

            services.AddSingleton<IStorage, MemoryStorage>();

            services.AddSingleton<ITelegramBotClient>(provider =>
            new TelegramBotClient(appSettings.BotToken));

            services.AddHostedService<Bot>();
        }

        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                //DownloadsFolder = @"C:\\Users\\Ванч\\Downloads",
                BotToken = "",
                //AudioFileName = "audio",
                //InputAudioFormat = "ogg"
            };
        }
    }
}