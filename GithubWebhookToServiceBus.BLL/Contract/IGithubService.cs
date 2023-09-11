using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.BusinessLibrary.Contract
{
    public interface IGithubService
    {
        public Task<string> FetchCommitDetails(string repositoryOwner, string repositoryName, string commitId);
    }
}
