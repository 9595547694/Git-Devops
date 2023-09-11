using Azure.Messaging.ServiceBus;
using GithubToDevopsApp.Adapters.Configuration;
using GithubToDevopsApp.Adapters.Contract;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.ApplicationInsights.Extensibility;

using Microsoft.Extensions.Logging;
using Microsoft.TeamFoundation.Build.WebApi;
using Newtonsoft.Json;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace GithubToDevopsApp.Adapters.Adapters
{
    public class ServiceBusAdapter : IServiceBusReceiver
    {
        //SecretConfig SecretServiceBus = new SecretConfig();
        String KeyVaultUri = "https://integrationappkeyvault.vault.azure.net/";


        public async Task<string> Receivefromtopic()
        {
           /* var KeyVaultSecret = new SecretClient(new Uri(KeyVaultUri), new DefaultAzureCredential());
            var ConnectionString = KeyVaultSecret.GetSecret("ServiceBusConn");
            var topic= KeyVaultSecret.GetSecret("ServiceTopicName");
           var sub= KeyVaultSecret.GetSecret("ServiceSubscription");*/
            ServiceBusClient serviceBusClient1 = new ServiceBusClient("Endpoint=sb://servicebuspayload.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=FTXKs6LCemYMIZaKLK5wB8/hZDGDFcKk8+ASbJNsvzg=");
            //ServiceBusClient serviceBusClient1 = new ServiceBusClient(ConnectionString.Value.Value);

            ServiceBusReceiver serviceBusReceiver1 = serviceBusClient1.CreateReceiver("githubtopic","githubsub",
            new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });
            //IAsyncEnumerable<ServiceBusReceivedMessage> messages = serviceBusReceiver1.ReceiveMessagesAsync();
            ServiceBusReceivedMessage messages = await serviceBusReceiver1.ReceiveMessageAsync();
            dynamic result = messages.Body;

            if (result != null)
            {
                return result.ToString();
            }
            else
            {
                return string.Empty;
            }
           /* await foreach (ServiceBusReceivedMessage message in messages)
            {
                Console.WriteLine(message.Body);
                dynamic result = message.Body;
                //string commitId = Encoding.Default.GetString(result);
                return message.Body.ToString();
            }*/
            

        }


    }
}