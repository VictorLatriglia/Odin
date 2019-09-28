using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.VisualRecognition.Models
{
    public class ObjectDetectedSquare
    {
        public double StartX { get; set; }
        public double EndX { get; set; }
        public double StartY { get; set; }
        public double EndY { get; set; }

        public ObjectDetectedSquare(double StartX, double EndX, double StartY, double EndY)
        {
            this.StartX = StartX;
            this.EndX = EndX;
            this.StartY = StartY;
            this.EndY = EndY;
        }
    }
}
