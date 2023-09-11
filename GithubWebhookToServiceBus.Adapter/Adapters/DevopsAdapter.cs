using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GithubToDevopsApp.Adapters.Contract;

namespace GithubToDevopsApp.Adapters.Adapters
{
    public class DevopsAdapter : IAzureDevops
    {
        public VssConnection login()
        {

            // Create Organization on Azure Devops and use that organization URL
            string orgUrl = "https://dev.azure.com/AzureDevOpsWorkItems/";

            //Create Personal Access Token from DevOps Portal
            string personalAccessToken = "eosdqggs6gvowcup5t5uw3mjl372qasn4hddg3htfpiem356d6yq";

            // It will Create a connection to the Azure DevOps
            VssConnection connection = new VssConnection
                (new Uri(orgUrl),
                new VssBasicCredential(string.Empty, personalAccessToken));
            return connection;

        }

        public async Task<string> createWorkItem(VssConnection connection,string title, string description)
        {
            //Project Name
            string projectName = "DevOpsWorkItems";

            // Get a reference to the Work Item Tracking HTTP client
            WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();

            // Create a new Work Item
            JsonPatchDocument workItemDocument = new JsonPatchDocument
        {
            new JsonPatchOperation()
            {
                Operation = Operation.Add,
                Path = "/fields/System.Title",
                Value = "Workitem:"+title
            },
            new JsonPatchOperation()
            {
                Operation = Operation.Add,
                Path ="/fields/System.Description",
                Value= "Changes made:"+description
            }
        };

            WorkItem result = await witClient.CreateWorkItemAsync(workItemDocument, projectName, "Task");


            //Console.WriteLine($"Created Task with ID: {result.Id}");
            Console.WriteLine(result.Id);
            string response = "Task created with Id:"+result.Id;
            return response;
        }

        
    }
}
