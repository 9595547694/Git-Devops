using GithubToDevopsApp.BusinessLibrary.Contract;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp
{
    public class AzureDevops
    {
        private readonly IDevopsService _devService;
        public AzureDevops(IDevopsService devService)
        {
            _devService = devService;
        }

         public async Task<string> createWorkItem(string title,string description)
        {
           string result= await _devService.createItem(title,description);
            return result;
        }
    }
}
