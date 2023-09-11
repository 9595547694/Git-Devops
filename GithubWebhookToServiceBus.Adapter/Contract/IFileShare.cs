using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.Adapters.Contract
{
    public interface IFileShare
    {
        public Task<string> uploadCode(string data, DateTime obj);
    }
}
