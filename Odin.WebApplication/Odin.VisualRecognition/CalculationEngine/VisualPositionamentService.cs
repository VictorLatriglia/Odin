using Odin.VisualRecognition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odin.VisualRecognition.CalculationEngine
{
    public class VisualPositionamentService
    {
        /// TODO: Replace this for whatever the device recognices
        private const double DegreesFromNorth = 290;
        private const double CameraPixelsWidth = 800;
        private const double CameraPixelsHeigth = 800;
        ///

        public static async Task<RecognicedObject> CalculatePosition(RecognicedObject @object)
        {
            //Had to put this on hold while i make som handwritten calculations...
            return @object;
        }
    }
}
