// See https://aka.ms/new-console-template for more information
using GithubToDevopsApp;
using GithubToDevopsApp.Adapters.Adapters;
using GithubToDevopsApp.Adapters.Contract;
using GithubToDevopsApp.BusinessLibrary.Contract;
using GithubToDevopsApp.BusinessLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System.Drawing.Text;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using GithubToDevopsApp.DataAccessObjects;

public class Program
{
    static async Task Main(string[] args)
    {
        IHost host = CreateHost();
        ReceiveServiceBusData dataobj = ActivatorUtilities.CreateInstance<ReceiveServiceBusData>(host.Services);
        string msg = await dataobj.ReceiveData();
        ReceiveCommitData obj = JsonConvert.DeserializeObject<ReceiveCommitData>(msg);
        Console.WriteLine(msg);
        /*ReceiveCommitData obj = new ReceiveCommitData();
        obj.CommitId = "326ed1d587d4a493be89258d8399fbbdecd3556a";
        obj.RepoName = "DemoRepo";
        obj.RepoOwner = "Ishika1101";
        obj.CommiterName = "ishika";*/
        if (obj != null)
        {
          GithubFetchData fetchData= ActivatorUtilities.CreateInstance<GithubFetchData>(host.Services);
          string response =await fetchData.FetchingByCommitId(obj.RepoOwner, obj.RepoName, obj.CommitId);
          GithubFileData  fileChangeData= JsonConvert.DeserializeObject<GithubFileData>(response);

            if(fileChangeData != null)
            {
                GithubToFileShare shareObj = ActivatorUtilities.CreateInstance<GithubToFileShare>(host.Services);
                string content = fileChangeData.fName + "\n" + fileChangeData.fContent;
                string result=shareObj.uploadContent(content,fileChangeData.changeDate);

                if(result != null) 
                {
                    AzureDevops devopsObj = ActivatorUtilities.CreateInstance<AzureDevops>(host.Services);
                    string res=await devopsObj.createWorkItem(obj.CommiterName, obj.RepoName);
                    Console.WriteLine(res);

                }
            }
            
            
        }

       


    }

    private static IHost CreateHost() =>
        Host.CreateDefaultBuilder()
      .ConfigureServices((context, services) =>
      {
          services.AddSingleton<IFileShare, FileShareAdapter>();
          services.AddSingleton<IFileShareService, FileShareService>();
          services.AddSingleton<IServiceBusReceiver, ServiceBusAdapter>();
          services.AddSingleton<IServiceBusService, ServiceBusService>();
          services.AddSingleton<IAzureDevops, DevopsAdapter>();
          services.AddSingleton<IDevopsService, DevopsService>();
          services.AddSingleton<IGithub, GithubAdapter>();
          services.AddSingleton<IGithubService, GithubService>();
      })
      .Build();

}

