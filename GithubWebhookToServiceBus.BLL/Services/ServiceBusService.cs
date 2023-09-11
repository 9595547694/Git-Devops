using GithubToDevopsApp.Adapters.Contract;
using GithubToDevopsApp.BusinessLibrary.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GithubToDevopsApp.BusinessLibrary.Services
{

    public class ServiceBusService : IServiceBusService
    {
        private readonly IServiceBusReceiver _receiver;
        public ServiceBusService(IServiceBusReceiver serviceBusReceiver)
        {
           _receiver = serviceBusReceiver;
        }


        public async Task<string> ReceiveFromServiceBus()
        {
            try
            {

                return await _receiver.Receivefromtopic();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
    }

}
