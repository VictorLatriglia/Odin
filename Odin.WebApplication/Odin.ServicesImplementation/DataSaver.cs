using Odin.DataAccess.Repository;
using Odin.Models;
using Odin.ServiceContracts;
using Odin.VisualRecognition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.ServicesImplementation
{
    public class DataSaver : IDataSaver
    {
        readonly IRepository<ObjectDetected, int> objectDetectedRepo;
        readonly IRepository<DetectionBatch, int> detectionBatchRepo;
        public DataSaver(
            IRepository<ObjectDetected, int> objectDetectedRepo,
            IRepository<DetectionBatch, int> detectionBatchRepo)
        {
            this.objectDetectedRepo = objectDetectedRepo;
            this.detectionBatchRepo = detectionBatchRepo;
        }

        public async Task SaveData(List<RecognicedObject> data)
        {
            await this.detectionBatchRepo.AddAsync(new DetectionBatch
            {
                Detections = data.Select(x=>
                    new ObjectDetected { Object = x.Detection.ToString(), Latitude = x.Latitude, Longitude = x.Longitude }).ToList()
            });
            await this.detectionBatchRepo.SaveChangesAsync();
        }

    }
}
