using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Odin.ServiceContracts;
using Odin.VisualRecognition.Models;
using Odin.WebApplication.Models;

namespace Odin.WebApplication.Controllers
{
    public class PositionamentController : Controller
    {
        readonly IDataSaver dataSaverService;
        public PositionamentController(
            IDataSaver dataSaverService)
        {
            this.dataSaverService = dataSaverService;
        }

        public async Task<string> Index(string jsonData)
        {
            var recognicedData = JsonConvert.DeserializeObject<IList<RecognicedData>>(jsonData);
            IRecognicedList elements = new RecognicedObjectList();
            foreach (var data in recognicedData.Where(x=>x.label.Equals("car")))
                elements.Add(new RecognicedObject(new ObjectDetectedSquare(data.startX, data.endX, data.startY, data.endY), ClassificationTypes.DetectionType.Car));

            foreach (var item in elements.CalculatePositions())
                await dataSaverService.SaveData(item);

            return "SUCCESS";
        }
    }
}