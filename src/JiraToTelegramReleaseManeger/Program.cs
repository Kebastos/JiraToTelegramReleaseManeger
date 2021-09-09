using JiraCommunication.Extensions;
using JiraToTelegramReleaseManager.Logic.HostedService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        var logger = LogManager.GetCurrentClassLogger();

        try
        {
            CreateHostBuilder(args).Build().Run();

        }
        catch (Exception e)
        {
            logger.Error($"Не удалось запустить сервис! \n{e.Message} \n {e.StackTrace}");
            if (e.InnerException != null)
                logger.Error(e.InnerException.Message);
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseEnvironment(Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT"))
                .ConfigureLogging(confLogging =>
                {
                    confLogging.AddNLog("nlog.config");
                })
                .ConfigureAppConfiguration((hostContext, service) =>
                {
                    service.AddEnvironmentVariables()
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true, true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddJiraClient(new JiraCommunication.Commons.Options.JiraOptions()
                    {
                        ServerUrl = "https://jira.russianpost.ru/",
                        UserName = "Kozyrev.Mikhail",
                        Password = "17910533Vrn"
                    });

                    services.AddHostedService<AppHostedService>();
                });
}