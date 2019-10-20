using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Odin.ServiceContracts;
using Odin.VisualRecognition.Models;
using Odin.WebApplication.Hubs;
using Odin.WebApplication.Models;
using Odin.WebApplication.Services;

namespace Odin.WebApplication.Controllers
{
    public class PositionamentController : Controller
    {
        readonly IDataSaver dataSaverService;
        readonly IHubContext<SupervisionHub> hubContext;
        readonly IRecognitionService recognitionService;
        public PositionamentController(
            IDataSaver dataSaverService,
            IHubContext<SupervisionHub> hubContext,
            IRecognitionService recognitionService)
        {
            this.dataSaverService = dataSaverService;
            this.hubContext = hubContext;
            this.recognitionService = recognitionService;
        }

        public async Task<string> Index(string jsonData)
        {
            var dataDetection = recognitionService.FromJsonToDetection(jsonData);
            //await dataSaverService.SaveData(dataDetection);

            string jsonProccess = JsonConvert.SerializeObject(dataDetection);
            await hubContext.Clients.All.SendAsync("dataUpdate", jsonProccess);

            return "SUCCESS";
        }
    }
}