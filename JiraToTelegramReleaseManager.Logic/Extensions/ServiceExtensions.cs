using JiraToTelegramReleaseManager.Common.Options;
using JiraToTelegramReleaseManager.Logic.HostedService;
using JiraToTelegramReleaseManager.Logic.Services.JiraClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JiraToTelegramReleaseManager.Logic.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Добавляет сервис клиента для работы с API Jira.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddJiraClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JiraOptions>(configuration.GetSection(nameof(JiraOptions)));
            services.AddSingleton<IJiraClientService, JiraClientService>();

            return services;
        }

        /// <summary>
        /// Добавляет хост-сервис, отвечающий за основную логику приложения.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppHostedService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<AppHostedService>();

            return services;
        }
    }
}
