using Odin.VisualRecognition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Odin.VisualRecognition.Models.ClassificationTypes;

namespace Odin.VisualRecognition.CalculationEngine
{
    public class VehicleConstant
    {
        public double RealSizeMM { get; set; }
        public string CVLabel { get; set; }
        public VehicleConstant(double realSizeMm, string cvLabel)
        {
            RealSizeMM = realSizeMm;
            CVLabel = cvLabel;
        }

        public static IList<VehicleConstant> ConstantsRegistered()
        {
            return new List<VehicleConstant>()
            {
                new VehicleConstant(1580,"Car")
            };
        }
    }
    public static class VisualPositionamentService
    {
        /// TODO: Replace this for whatever the device recognices
        private const double DegreesFromNorth = 0;
        private const double CameraPixelsWidth = 800;
        private const double CameraPixelsHeight = 800;
        private const double CameraAOV = 60;
        private const double CameraFocalLenght = 11;
        private const double CameraHeight = 100;
        private const double lat0 = 5.331761;
        private const double lon0 = -72.398830;
        private static readonly double DegreesPerPixel = CameraAOV / (Math.Sqrt(Math.Pow(CameraPixelsHeight, 2) + Math.Pow(CameraPixelsWidth, 2)));
        ///

        public static RecognicedObject CalculatePosition(RecognicedObject recognicedObject)
        {
            var realData = VehicleConstant.ConstantsRegistered();
            var constantReading = realData.FirstOrDefault(x => x.CVLabel.Equals(recognicedObject.Detection.ToString()))?.RealSizeMM ?? 0;
            if (constantReading != 0)
            {
                var ObjectHeight = recognicedObject.DetectionSquare.EndY - recognicedObject.DetectionSquare.StartY;
                var distanceToObject = ((CameraFocalLenght * constantReading * CameraPixelsHeight) / (ObjectHeight * CameraHeight))/1000;
                if (DegreesFromNorth == 0)
                {
                    var pixelsFromNorth = CameraPixelsWidth - recognicedObject.DetectionSquare.StartX;
                    if (pixelsFromNorth < 0)
                        pixelsFromNorth *= -1;
                    var degreesOffset = pixelsFromNorth * DegreesPerPixel;
                    long offsetFromNorth = (long)(distanceToObject * Math.Cos(degreesOffset));
                    long offsetFromWest = (long)Math.Sqrt(Math.Pow(distanceToObject, 2) - Math.Pow(offsetFromNorth, 2));
                    //TODO: Fix positionament rounding
                    long lat = (long)(lat0 + (180 / Math.PI) * (offsetFromNorth / 6378137));
                    long lon = (long)(lon0 + (180 / Math.PI) * (offsetFromWest / 6378137) / Math.Cos(lat0));
                    recognicedObject.Latitude = lat;
                    recognicedObject.Longitude = lon;
                }
            }
            return recognicedObject;
        }
    }
}
