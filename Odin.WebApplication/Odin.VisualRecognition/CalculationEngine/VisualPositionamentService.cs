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
        private const double DegreesFromNorth = 310;
        private const double CameraPixelsWidth = 800;
        private const double CameraPixelsHeight = 800;
        private const double CameraAOV = 60;
        private const double CameraFocalLenght = 11;
        private const double CameraHeight = 100;
        private const double lat0 = 5.33187144;
        private const double lon0 = -72.39886174;
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
                if (DegreesFromNorth != 0)
                {
                    var pixelsFromNorth = CameraPixelsWidth - recognicedObject.DetectionSquare.StartX;
                    if (pixelsFromNorth < 0)
                        pixelsFromNorth *= -1;
                    var degreesOffset = pixelsFromNorth * DegreesPerPixel;
                    distanceToObject += 10;
                    double offsetFromNorth = (distanceToObject * Math.Cos(degreesOffset));
                    double offsetFromWest = Math.Sqrt(Math.Pow(distanceToObject, 2) - Math.Pow(offsetFromNorth, 2));
                    if (degreesOffset > (CameraAOV / 2))
                    {
                        offsetFromWest*= -1;
                        offsetFromWest -= 10;
                    }
                    decimal lat = Convert.ToDecimal(lat0 + (180 / Math.PI) * (offsetFromNorth / 6378137));
                    decimal lon = Convert.ToDecimal(lon0 + (180 / Math.PI) * (offsetFromWest / 6378137) / Math.Cos(lat0));
                    recognicedObject.Latitude = lat;
                    recognicedObject.Longitude = lon;
                }
            }
            return recognicedObject;
        }
    }
}
