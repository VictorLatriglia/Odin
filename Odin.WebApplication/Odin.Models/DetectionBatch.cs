using Odin.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.Models
{
    public class DetectionBatch : EntityBase<int>
    {
        public IList<ObjectDetected> Detections { get; set; }
    }
}
