using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubToDevopsApp.DataAccessObjects
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class GithubFileData
    {
        [JsonProperty("files[0].filename")]
        public string fName { get; set; }
        
        [JsonProperty("files[0].patch")]
        public string fContent { get; set; }

        [JsonProperty("commit.committer.date")]
        public DateTime changeDate { get; set; }
    }
}
