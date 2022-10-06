using _153505_Kiselev_Lab2.Collection;

namespace _153505_Kiselev_Lab2.Entities {
    internal class Сlient {
        public Сlient(string name) {
            rooms = new MyCustomCollection<Room>();
            Name = name;
            costOfLiving = 0;
        }

        private MyCustomCollection<Room> rooms;

        private float costOfLiving;
        public float CostOfLiving {
            get {
                costOfLiving = 0;

                for (short i = 0; i < rooms.Count; ++i) {
                    costOfLiving += rooms[i].Price;
                }

                return costOfLiving;
            }
            set {
                costOfLiving = value;
            }
            
        }
        public string Name { get; set; }

        public MyCustomCollection<Room> GetRooms() {
            return rooms;
        }

        public void AddRooms(Room item) {
            rooms.Add(item);
        }

        public void RemoveRooms(Room item) {
            rooms.Remove(item);
        }
    }
}
