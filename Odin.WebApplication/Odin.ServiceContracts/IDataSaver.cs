using Odin.VisualRecognition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odin.ServiceContracts
{
    public interface IDataSaver
    {
        Task SaveData(RecognicedObject data);
    }
}
