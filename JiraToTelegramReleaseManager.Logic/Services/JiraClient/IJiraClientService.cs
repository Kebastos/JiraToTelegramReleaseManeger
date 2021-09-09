using Atlassian.Jira;

namespace JiraToTelegramReleaseManager.Logic.Services.JiraClient
{
    /// <summary>
    /// Интерфейс клиента для взаимодействия с API Jira
    /// </summary>
    public interface IJiraClientService
    {
        /// <summary>
        /// Получить последнюю доступную версию
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProjectVersion>> GetLastVersion(CancellationToken cancellationToken);
    }
}
