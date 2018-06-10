using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableImageTest.Models
{
    // This randomizes the organization of the list for the answers
    static class AnsRandomizer
    {
        public static void Shuffle<T>(this Random rearrange, T[] indexArray)
        {
            int count = indexArray.Length;
            while (count > 1)
            {
                int k = rearrange.Next(count--);
                T temp = indexArray[count];
                indexArray[count] = indexArray[k];
                indexArray[k] = temp;
            }
        }
    }
}
