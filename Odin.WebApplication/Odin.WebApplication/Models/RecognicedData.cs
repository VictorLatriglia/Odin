using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odin.WebApplication.Models
{
    public class RecognicedData
    {
        public int endY { get; set; }
        public int endX { get; set; }
        public int startY { get; set; }
        public int startX { get; set; }
        public string label { get; set; }
    }
}
