using GithubToDevopsApp.BusinessLibrary.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp
{
    public class GithubToFileShare
    {
        private readonly IFileShareService _fileShareService;

        public GithubToFileShare(IFileShareService fileShareService)
        {
           _fileShareService = fileShareService;
        }

        public string uploadContent(string content,DateTime obj) 
        {
            var result = _fileShareService.uploadCodeToFileShare(content,obj);
            return result.ToString();
        }
    }
}
