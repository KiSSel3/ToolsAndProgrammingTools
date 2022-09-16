using _153505_Kiselev_Lab1.Collection;

namespace _153505_Kiselev_Lab1.Entities {
    internal class Hotel {
        public Hotel() {
            roomsCollection = new MyCustomCollection<Room>();
            clientCollection = new MyCustomCollection<Сlient>();
        }

        private MyCustomCollection<Room> roomsCollection;
        private MyCustomCollection<Сlient> clientCollection;

        public void AddRoom(int number, float price) {
            roomsCollection.Add(new Room(number, price));
        }

        public void AddClient(string name) {
            clientCollection.Add(new Сlient(name));
        }

        public void BookRoom(string name, int number) {
            for (short i = 0; i < clientCollection.Count; ++i) {
                if (clientCollection[i].Name.Equals(name)) {
                    for (short j = 0; j < roomsCollection.Count; ++j) {
                        if (roomsCollection[j].Number.Equals(number)) {
                            if (roomsCollection[j].RoomIsFree) {
                                clientCollection[i].AddRooms(roomsCollection[j]);

                                roomsCollection[j].RoomIsFree = false;
                            }
                            else {
                                Console.WriteLine("\nДанная комната занята\n");
                            }                         

                            return;
                        }
                    }
                }
            }

            Console.WriteLine("\nНеверные данные!\n");
        }

        public void FreeRooms() {
            for (int i = 0; i < roomsCollection.Count; ++i) {
                if (roomsCollection[i].RoomIsFree) {
                    Console.WriteLine($"Номер комнаты: {roomsCollection[i].Number} || Цена: {roomsCollection[i].Price}");
                }
            }
        }

        public void ClientInfo() {
            for (int i = 0; i < clientCollection.Count; ++i) {
                Console.WriteLine($"Клиент: {clientCollection[i].Name} || Цена: {clientCollection[i].CostOfLiving}");
            }
        }

        public void InfoRooms() {
            for (int i = 0; i < roomsCollection.Count; ++i) {
                var state = (roomsCollection[i].RoomIsFree) ? "Cвободна" : "Занята";
                Console.WriteLine($"Номер комнаты: {roomsCollection[i].Number} || Цена: {roomsCollection[i].Price}  || Состояние: {state}");
            }
        }
    }
}
