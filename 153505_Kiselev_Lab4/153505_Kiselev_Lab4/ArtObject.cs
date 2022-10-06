using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Kiselev_Lab4
{
    internal class ArtObject
    {
        public ArtObject(string name, int dateOfCreation, bool available) => (Name, DateOfCreation, Available) = (name, dateOfCreation, available);
        public string Name      { get ; private set; }
        public int    DateOfCreation     { get; set; }
        public bool   Available { get; set; }
    }
}
