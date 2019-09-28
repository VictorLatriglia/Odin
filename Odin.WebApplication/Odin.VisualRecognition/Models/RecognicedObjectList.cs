using Odin.VisualRecognition.CalculationEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Odin.VisualRecognition.Models
{
    public class RecognicedObjectList : IRecognicedList
    {
        private readonly IList<RecognicedObject> List;

        public RecognicedObject this[int index] { get => List[index]; set => List[index] = value; }

        public int Count => List.Count;

        public bool IsReadOnly => List.IsReadOnly;

        public RecognicedObjectList()
        {
            List = new List<RecognicedObject>();
        }

        public async IAsyncEnumerable<RecognicedObject> CalculatePositions(double offsetDegrees)
        {
            if (List.Count > 0)
            {
                foreach (RecognicedObject item in List)
                {
                    yield return await VisualPositionamentService.CalculatePosition(item);
                }
            }
        }

        public void Add(RecognicedObject item)
        {
            List.Add(item);
        }

        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(RecognicedObject item) => List.Contains(item);

        public void CopyTo(RecognicedObject[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        public IEnumerator<RecognicedObject> GetEnumerator()=> List.GetEnumerator();

        public int IndexOf(RecognicedObject item) => List.IndexOf(item);

        public void Insert(int index, RecognicedObject item)
        {
            List.Insert(index, item);
        }

        public bool Remove(RecognicedObject item) => List.Remove(item);

        public void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() => List.GetEnumerator();
    }
}
