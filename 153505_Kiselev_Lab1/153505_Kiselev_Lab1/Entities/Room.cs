using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Kiselev_Lab1.Entities {
    internal class Room {
        public Room(int number, float price) {
            Number = number;
            Price = price;
            RoomIsFree = true;
        } 

        public int Number { get; set; }
        public float Price { get; set; }
        public bool RoomIsFree { get; set; }        
    }
}
