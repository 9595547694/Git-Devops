using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GithubToDevopsApp.Adapters.Contract;
using GithubToDevopsApp.Adapters.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Reflection.Metadata;
using System.IO.Enumeration;

namespace GithubToDevopsApp.Adapters.Adapters
{
    public class FileShareAdapter : IFileShare
    {
        //-------------------------------------------------
        // Create a file share
        //-------------------------------------------------
        public async Task<string> uploadCode(string data,DateTime dateObj)
        {
             
            // Get the connection string from config
            SecretConfig secretConfig = new SecretConfig();
            //string connectionString= secretConfig.GetStorageAccountConnectionString();
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=demostoragefileshare;AccountKey=B0IEZaVifPbDxQKVQ3j9RteZ6kTqW9GaUCov1JmAHe74FPWKjFzF3m9+WWOD77hFt4EwIFETc22y+AStauwhfQ==;EndpointSuffix=core.windows.net";

            // Instantiate a ShareClient which will be used to create and manipulate the file share
            ShareClient share = new ShareClient(connectionString, "fileshare");

            // Create the share if it doesn't already exist
             share.CreateIfNotExistsAsync();

            // Ensure that the share exists
            
            if (share.Exists())
            {
                Console.WriteLine($"Share created: {share.Name}");

                // Get a reference to the sample directory
                ShareDirectoryClient directory = share.GetDirectoryClient("GithubData");

                // Create the directory if it doesn't already exist
                 directory.CreateIfNotExistsAsync();

                // Ensure that the directory exists
                if ( directory.Exists())
                {
                    Random random = new Random();
                   //string fileName  = "/Changes:"+dateObj+".txt";
                    int no = random.Next(1, 50);
                    string number=no.ToString();
                    string fileName = "/Change"+number;
                    ShareFileClient fileClient = new ShareFileClient(connectionString, share.Name, directory.Name+fileName );
                    

                    // Ensure that the file exists
                    if (!fileClient.Exists())
                    {
                        fileClient.Create(500);
                        string filecontent = data;
                        byte[] byteArray = Encoding.UTF8.GetBytes(filecontent);
                        MemoryStream stream1 = new MemoryStream(byteArray);
                        stream1.Position = 0;
                        fileClient.Upload(stream1);
                        await stream1.FlushAsync();
                        stream1.Close();

                        /*using FileStream fs = File.OpenWrite(fileClient.Name);

                         data = "falcon\nhawk\nforest\ncloud\nsky";
                        byte[] bytes = Encoding.UTF8.GetBytes(data);

                        fs.Write(bytes, 0, bytes.Length);*/
                        

                    }
                    
                }
                return "File Uploaded";
            }
            else
            {
                Console.WriteLine($"CreateShareAsync failed");
                return null;
            }
        }

        
    }
}
