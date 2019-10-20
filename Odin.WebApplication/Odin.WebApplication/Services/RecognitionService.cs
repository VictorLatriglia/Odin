using Newtonsoft.Json;
using Odin.VisualRecognition.Models;
using Odin.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odin.WebApplication.Services
{
    public interface IRecognitionService
    {
        List<RecognicedObject> FromJsonToDetection(string JsonData);
    }
    public class RecognitionService : IRecognitionService
    { 
        public List<RecognicedObject> FromJsonToDetection(string jsonData)
        {
            var recognicedData = JsonConvert.DeserializeObject<IList<RecognicedData>>(jsonData);
            IRecognicedList elements = new RecognicedObjectList();
            foreach (var data in recognicedData.Where(x => x.label.Equals("car") || x.label.Equals("motorbike")))
                elements.Add(new RecognicedObject(new ObjectDetectedSquare(data.startX, data.endX, data.startY, data.endY), ClassificationTypes.DetectionType.Car));
            List<RecognicedObject> dataDetection = new List<RecognicedObject>();
            dataDetection.AddRange(elements.CalculatePositions());
            return dataDetection;
        }
    }
}
