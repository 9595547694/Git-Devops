using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.Adapters.Configuration
{
    public class SecretConfig
    {
        String KeyVaultUri = "https://integrationappkeyvault.vault.azure.net/";

        public string GetServicebusConnectionString()
        {

            var KeyVaultSecret = new SecretClient(new Uri(KeyVaultUri), new DefaultAzureCredential());
            var ConnectionString = KeyVaultSecret.GetSecret("");
            return ConnectionString.Value.Value;

        }

        public string GetTopicName()
        {
            var KeyVaultSecret = new SecretClient(new Uri(KeyVaultUri), new DefaultAzureCredential());
            var TopicName = KeyVaultSecret.GetSecret("");
            return TopicName.Value.Value;
        }

        public string GetSubscriptionName()
        {
            var KeyVaultSecret = new SecretClient(new Uri(KeyVaultUri), new DefaultAzureCredential());
            var SubscriptionName = KeyVaultSecret.GetSecret("");
            return SubscriptionName.Value.Value;
        }


        public string GetStorageAccountConnectionString()
        {

            var keyVaultSecret = new SecretClient(new Uri(KeyVaultUri), new DefaultAzureCredential());
            //var ConnectionString = keyVaultSecret.GetSecret("StorageAccountConn");
            var secret = keyVaultSecret.GetSecretAsync("StorageAccountConn").GetAwaiter().GetResult();

            return secret.Value.Value;



        }


        public string GetStorageAccountName()
        {
            var KeyVaultSecret = new SecretClient(new Uri(KeyVaultUri), new DefaultAzureCredential());

            var name = KeyVaultSecret.GetSecret("StorageAccountName");
            return name.Value.Value;

        }
        public string GetStorageAccountKey()
        {

            var KeyVaultSecret = new SecretClient(new Uri(KeyVaultUri), new DefaultAzureCredential());
            var sKey = KeyVaultSecret.GetSecret("");
            return sKey.Value.Value;

        }

    }
}
