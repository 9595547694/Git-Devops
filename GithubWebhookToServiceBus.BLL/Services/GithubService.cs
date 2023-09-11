using GithubToDevopsApp.Adapters.Adapters;
using GithubToDevopsApp.Adapters.Contract;
using GithubToDevopsApp.BusinessLibrary.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.BusinessLibrary.Services
{
    public class GithubService:IGithubService
    {
        private readonly IGithub _githubAdapter;

        public GithubService(IGithub githubAdapter)
        {
            _githubAdapter = githubAdapter;
        }

        public async Task<string> FetchCommitDetails(string repositoryOwner, string repositoryName, string commitId)
        {

            try
            {
                string commitDetails = await _githubAdapter.GetCommitDetails(repositoryOwner, repositoryName, commitId);
                return commitDetails;
                Console.WriteLine(commitDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching commit details: {ex.Message}");
                return null;
            }
        }
    }
}
