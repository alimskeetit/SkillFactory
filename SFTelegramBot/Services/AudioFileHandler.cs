using SFTelegramBot.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SFTelegramBot.Services
{
    public class AudioFileHandler : IFileHandler
    {
        private readonly AppSettings _appSettings;
        private readonly ITelegramBotClient _telegramBotClient;
    
        private AudioFileHandler(ITelegramBotClient telegramBotClient,
                                AppSettings appSettings)
        {
            _appSettings = appSettings;
            _telegramBotClient = telegramBotClient;
        }

        public async Task Download(string fileId, CancellationToken ct)
        {
            string inputAudioFilePath = Path.Combine(_appSettings.DownloadsFolder,
                                        $"{_appSettings.AudioFileName}.{_appSettings.InputAudioFormat}");
            using (FileStream destinationStream = File.Create(inputAudioFilePath))
            {
                var file = await _telegramBotClient.GetFileAsync(fileId, ct);
                if (file.FilePath == null)
                    return;
                await _telegramBotClient.DownloadFileAsync(file.FilePath, destinationStream, ct);
            }
        }

        public string Process(string languageCode)
        {
            throw new NotImplementedException();
        }
    }
}
