using GithubToDevopsApp.BusinessLibrary.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp
{
    public class GithubFetchData
    {
        private readonly IGithubService _githubService;
        public GithubFetchData(IGithubService githubService)
        {
           _githubService = githubService;
        }

        public async Task<string> FetchingByCommitId(string repositoryOwner, string repositoryName, string commitId)
        {
            var result = await _githubService.FetchCommitDetails(repositoryOwner,repositoryName,commitId);
            return result.ToString();
        }
    }
}
