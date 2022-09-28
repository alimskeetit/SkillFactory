using SFTelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFTelegramBot.Services
{
    public interface IStorage
    {
        /// <summary>
        /// Получение сессии пользователя по идентификатору
        /// </summary>
        Session GetSession(in long chatID);
    }
}
