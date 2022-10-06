using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Kiselev_Lab3.Entities
{
    internal class Room
    {
        public Room(float price, int number) => (Price, Number) = (price, number);

        public int Number { get; set; }
        public float Price { get; set; }
        public bool RoomIsFree { get; set; } = true;
    }
}
