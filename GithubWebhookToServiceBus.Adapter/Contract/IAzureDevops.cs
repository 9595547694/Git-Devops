using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.Adapters.Contract
{
    public interface IAzureDevops
    {
        public VssConnection login();
        public   Task<string> createWorkItem(VssConnection connection,string title,string description);
    }
}
