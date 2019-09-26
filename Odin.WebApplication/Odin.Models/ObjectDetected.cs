using Odin.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.Models
{
    public class ObjectDetected : EntityBase<int>
    {
        public string Object { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
