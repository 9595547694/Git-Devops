using GithubToDevopsApp.BusinessLibrary.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace GithubToDevopsApp
{
    public class ReceiveServiceBusData
    {

        private readonly IServiceBusService _serviceBusService;
        public ReceiveServiceBusData(IServiceBusService serviceBusService)
        {
            _serviceBusService = serviceBusService;
        }

        public async Task<string> ReceiveData()
        {
            var result = await _serviceBusService.ReceiveFromServiceBus();
            return result.ToString();
        }
    }
}
