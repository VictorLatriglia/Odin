using Odin.DataAccess.Repository;
using Odin.Models;
using Odin.ServiceContracts;
using Odin.VisualRecognition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odin.ServicesImplementation
{
    public class DataSaver : IDataSaver
    {
        readonly IRepository<ObjectDetected, int> objectDetectedRepo;
        public DataSaver(
            IRepository<ObjectDetected, int> objectDetectedRepo)
        {
            this.objectDetectedRepo = objectDetectedRepo;
        }

        public async Task SaveData(RecognicedObject data)
        {
            await this.objectDetectedRepo.AddAsync(new ObjectDetected { Object = data.Detection.ToString(), Latitude = Convert.ToDecimal(data.Latitude), Longitude = Convert.ToDecimal(data.Longitude) });
            await this.objectDetectedRepo.SaveChangesAsync();
        }
        
    }
}
