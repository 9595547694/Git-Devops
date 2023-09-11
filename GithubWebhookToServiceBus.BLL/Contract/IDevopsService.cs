using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.BusinessLibrary.Contract
{
    public interface IDevopsService
    {
        public Task<string> createItem(string title,string description);

    }
}
