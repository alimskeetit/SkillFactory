using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using SFTelegramBot.Controllers;
using SFTelegramBot.Servies;
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
            services.AddSingleton(appSettings);

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
                BotToken = "5743891062:AAEGXqbMCHO6TXpEJbXGaaM-YKRQ0k6g2rc"
            };
        }
    }
}