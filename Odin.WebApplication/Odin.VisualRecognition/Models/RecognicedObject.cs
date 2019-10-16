using System;
using System.Collections.Generic;
using System.Text;
using static Odin.VisualRecognition.Models.ClassificationTypes;

namespace Odin.VisualRecognition.Models
{
    public class RecognicedObject
    {
        public ObjectDetectedSquare DetectionSquare { get; set; }
        public double Latitude { get; internal set; }
        public double Longitude { get; internal set; }
        public DetectionType Detection { get; set; }

        public RecognicedObject(ObjectDetectedSquare objectDetected, DetectionType detectionType)
        {
            this.DetectionSquare = objectDetected;
            this.Detection = detectionType;
        }
    }
}
