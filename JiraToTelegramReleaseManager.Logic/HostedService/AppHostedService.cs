using JiraCommunication.Services.JiraClient;
using Microsoft.Extensions.Hosting;

namespace JiraToTelegramReleaseManager.Logic.HostedService
{
    public class AppHostedService : IHostedService
    {
        private readonly IJiraClientService _jiraClient;

        public AppHostedService(IJiraClientService jiraClient)
        {
            _jiraClient = jiraClient;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var data = _jiraClient.GetVersions("E4P");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
