using Telegram.Bot;
using Telegram.Bot.Types;
using SFTelegramBot.Configuration;
using SFTelegramBot.Services;

namespace SFTelegramBot.Controllers
{
    internal class VoiceMessageController
    {
        private readonly AppSettings _appSettings;
        private readonly ITelegramBotClient _telegramClient;
        private readonly IFileHandler _audioFileHandler;

        public VoiceMessageController(ITelegramBotClient telegramClient,
                                        AppSettings appSettings,
                                        IFileHandler audioFileHandler)
        {
            _telegramClient = telegramClient;
            _appSettings = appSettings;
            _audioFileHandler = audioFileHandler;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            var fileId = message.Voice?.FileId;
            if (fileId == null)
                return;

            await _audioFileHandler.Download(fileId, ct);

            await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                "Голосовое сообщение загружено", cancellationToken: ct);
        }
    }
}
