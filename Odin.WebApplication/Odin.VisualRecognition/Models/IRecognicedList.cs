using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.VisualRecognition.Models
{
    public interface IRecognicedList : IList<RecognicedObject>
    {
        IEnumerable<RecognicedObject> CalculatePositions();
    }
}
