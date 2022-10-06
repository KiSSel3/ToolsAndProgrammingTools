using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Kiselev_Lab3.Entities
{
    internal class Client
    {
        public Client(string name) => Name = name; 
        public string Name { get; set; }

        private List<Room> rooms = new();

        private float costOfLiving = 0;
        public float CostOfLiving
        {
            get
            {
                costOfLiving = 0;

                foreach(var room in rooms)
                {
                    costOfLiving += room.Price;
                }

                return costOfLiving;
            }

            private set
            {
                costOfLiving = value;
            }
        }
        public List<Room> GetRooms()
        {
            return rooms;
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        public void RemoveRoom(Room room)
        {
            rooms.Remove(room);
        }
    }
}
