using GithubToDevopsApp.Adapters.Contract;
using GithubToDevopsApp.BusinessLibrary.Contract;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.BusinessLibrary.Services
{
    public class DevopsService:IDevopsService
    {
        private readonly IAzureDevops _devops;
        public DevopsService(IAzureDevops devops)
        {
            _devops= devops;
                
        }

        public async Task<string> createItem(string title,string description)
        {
            try
            {
                VssConnection conn = _devops.login();
               
                string result= await _devops.createWorkItem(conn,title,description);
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

       
        
    }
}

