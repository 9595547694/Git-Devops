using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Messaging.ServiceBus;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class ReceiverServiceBus
    {
       
        [FunctionName("ReceiverServiceBus")]
        public void Run([ServiceBusTrigger("payloadtopic", "payloadsubscription", Connection ="serivcebusconn")]string mySbMsg)
        {
            
            IServiceCollection services = new ServiceCollection();
            var channel = new ServerTelemetryChannel();
            services.Configure<TelemetryConfiguration>(
                (config) =>
                {
                    config.TelemetryChannel = channel;
                }
                );
            services.AddLogging(builder =>
            {
                builder.AddApplicationInsights("51f7edb3-8691-49d2-bfcf-666e40ce3b09");
             

            });
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ILogger<ReceiverServiceBus> logger = serviceProvider.GetRequiredService<ILogger<ReceiverServiceBus>>();
          
            logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "docker",
                    Arguments = "run --rm my-container-app-image",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = new Process())
                {
                    process.StartInfo = processInfo;
                    process.Start();
                    process.WaitForExit();
                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                    logger.LogInformation($"Process Output: {output}");
                    logger.LogInformation($"Process Error: {error}");
                }

                logger.LogInformation("Containerized console app started successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error starting containerized console app: {ex.Message}");
            }
        }




    }
}

