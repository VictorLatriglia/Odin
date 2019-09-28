using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.VisualRecognition.Models
{
    public interface IRecognicedList : IList<RecognicedObject>
    {
        IAsyncEnumerable<RecognicedObject> CalculatePositions(double offsetDegrees);
    }
}
