using Telegram.Bot;
using Telegram.Bot.Types;
using SFTelegramBot.Configuration;
using SFTelegramBot.Services;

namespace SFTelegramBot.Controllers
{
    internal class VoiceMessageController
    {
        private readonly IStorage _memoryStorage;
        private readonly AppSettings _appSettings;
        private readonly ITelegramBotClient _telegramClient;
        private readonly IFileHandler _audioFileHandler;

        public VoiceMessageController(ITelegramBotClient telegramClient,
                                        AppSettings appSettings,
                                        IFileHandler audioFileHandler, 
                                        IStorage memoryStorage)
        {
            _telegramClient = telegramClient;
            _appSettings = appSettings;
            _audioFileHandler = audioFileHandler;
            _memoryStorage = memoryStorage;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            var fileId = message.Voice?.FileId;
            if (fileId == null)
                return;

            await _audioFileHandler.Download(fileId, ct);;

            string userLanguageCode = _memoryStorage.GetSession(message.Chat.Id).LanguageCode;
            var result = _audioFileHandler.Process(userLanguageCode);
            await _telegramClient.SendTextMessageAsync(message.Chat.Id, result, cancellationToken: ct);
        }
    }
}
