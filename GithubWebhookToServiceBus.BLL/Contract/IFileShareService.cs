using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.BusinessLibrary.Contract
{
    public interface IFileShareService
    {
        public Task<string> uploadCodeToFileShare(string data,DateTime obj);
    }
}
