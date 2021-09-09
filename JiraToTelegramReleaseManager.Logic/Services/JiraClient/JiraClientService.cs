using Atlassian.Jira;
using JiraToTelegramReleaseManager.Common.Options;
using Microsoft.Extensions.Options;

namespace JiraToTelegramReleaseManager.Logic.Services.JiraClient
{
    public class JiraClientService : IJiraClientService
    {
        private readonly Jira _jiraClient;
        private readonly JiraOptions _jiraOptions;
        public JiraClientService(IOptionsMonitor<JiraOptions> optionMonitors)
        {
            _jiraClient = Jira.CreateRestClient("http://<your_jira_server>", "<user>", "<password>");
            _jiraOptions = optionMonitors.CurrentValue;
        }

        public async Task<IEnumerable<ProjectVersion>> GetLastVersion(CancellationToken cancellationToken)
        {
            return await _jiraClient.Versions.GetVersionsAsync(_jiraOptions.ProjectName, cancellationToken);
        }
    }
}
