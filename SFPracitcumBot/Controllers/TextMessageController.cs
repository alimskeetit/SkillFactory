using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SFPracitcumBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient telegramBotClient;

        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            this.telegramBotClient = telegramBotClient;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                default:
                    break;
            }
        }
    }
}
