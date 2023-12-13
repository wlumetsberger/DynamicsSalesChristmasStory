using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Dataverse.Client;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        
    }).ConfigureServices((host, builder) =>
    {
        var serviceClient = new ServiceClient(new Uri(host.Configuration.GetValue<string>("DATAVERSE_ENV")), async (string dataverseUri) =>
        {
            dataverseUri = new Uri(dataverseUri).GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped);
            return (await new DefaultAzureCredential().GetTokenAsync(new TokenRequestContext(new[] { $"{dataverseUri}/.default" }), default)).Token;
        }, useUniqueInstance: true, logger: builder.BuildServiceProvider().GetService<ILogger<Program>>());
        if (!serviceClient.IsReady) throw new Exception("Authentication Failed!");
        builder.AddSingleton<ServiceClient>(serviceClient);

    })
    .Build();

host.Run();
