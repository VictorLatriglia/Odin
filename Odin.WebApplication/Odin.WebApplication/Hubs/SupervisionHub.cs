using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Odin.WebApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odin.WebApplication.Hubs
{
    public class SupervisionHub : Hub
    {
        IRecognitionService recognitionService;
        public SupervisionHub(IRecognitionService recognitionService)
        {
            this.recognitionService = recognitionService;
        }
        [HubMethodName("dataUpdate")]
        public Task DataDownloadSignal(string serializedProcess)
        {
            return Clients.All.SendAsync("dataUpdate", serializedProcess);
        }

        [HubMethodName("dataSend")]
        public Task DataProccessSignal(string JsonData)
        {
            var data = recognitionService.FromJsonToDetection(JsonData);
            var serializedProcess = JsonConvert.SerializeObject(data);
            return Clients.All.SendAsync("dataUpdate", serializedProcess);
        }
    }
}
