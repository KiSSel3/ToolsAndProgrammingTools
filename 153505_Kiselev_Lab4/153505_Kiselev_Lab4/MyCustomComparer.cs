using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Kiselev_Lab4
{
    internal class MyCustomComparer : IComparer<ArtObject>
    {
        public  int Compare(ArtObject? x, ArtObject? y) => x.Name.CompareTo(y.Name);
    }
}
