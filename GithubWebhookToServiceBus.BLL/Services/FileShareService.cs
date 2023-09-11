using GithubToDevopsApp.Adapters.Contract;
using GithubToDevopsApp.BusinessLibrary.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.BusinessLibrary.Services
{
    public class FileShareService:IFileShareService
    {
        private readonly IFileShare fileShareObj;
        public FileShareService(IFileShare fileShareObj) 
        { 
            this.fileShareObj = fileShareObj;
            
        }

        public async Task<string> uploadCodeToFileShare(string githubData,DateTime obj)
        {
            try
            {

                return await fileShareObj.uploadCode(githubData,obj);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
    }
}
