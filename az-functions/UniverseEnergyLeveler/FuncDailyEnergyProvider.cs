using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace UniverseEnergyLeveler
{
    public class FuncDailyEnergyProvider(ILogger<FuncDailyEnergyProvider> logger, ServiceClient serviceClient)
    {
       

        [Function("FuncDailyEnergyProvider")]
        public void Run([TimerTrigger("* * * * * *")] TimerInfo myTimer)
        {
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
            logger.LogInformation(serviceClient.ExecuteOrganizationRequest(new WhoAmIRequest()).ToString());
            //Todo Implement Logic to Upgrade Santas EnergyStore
        }
    }
}
