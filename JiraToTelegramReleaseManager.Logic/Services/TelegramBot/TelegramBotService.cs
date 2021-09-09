using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraToTelegramReleaseManager.Logic.Services.TelegramBot
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly ILogger<TelegramBotService> _logger;
        public TelegramBotService(ILogger<TelegramBotService> logger)
        {
            _logger = logger;
        }
    }
}
