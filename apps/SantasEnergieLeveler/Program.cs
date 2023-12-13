using Azure.Core;
using Azure.Identity;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerPlatform.Dataverse.Client;


var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("developer.appsettings.json", optional: true);
IConfiguration config = builder.Build();
Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", config.GetValue<string>("AZURE_CLIENT_ID"));
Environment.SetEnvironmentVariable("AZURE_TENANT_ID", config.GetValue<string>("AZURE_TENANT_ID"));
Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", config.GetValue<string>("AZURE_CLIENT_SECRET"));


var client = new ServiceClient(new Uri(config.GetValue<string>("DATAVERSE_ENV")), async (string dataverseUri) =>
{
    dataverseUri = new Uri(dataverseUri).GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped);
    return (await new DefaultAzureCredential().GetTokenAsync(new TokenRequestContext(new[] { $"{dataverseUri}/.default" }), default)).Token;
});

Console.WriteLine(client.ExecuteOrganizationRequest(new WhoAmIRequest()));