using _153505_Kiselev_Lab2.Collection;
using System.Diagnostics;

namespace _153505_Kiselev_Lab2.Entities {
    internal class Hotel {
        public delegate void EventHandler(string message);
        public EventHandler AddEvent;
        public EventHandler BookEvent;

        public Hotel() {
            roomsCollection = new MyCustomCollection<Room>();
            clientCollection = new MyCustomCollection<Сlient>();
        }

        private MyCustomCollection<Room> roomsCollection;
        private MyCustomCollection<Сlient> clientCollection;

        public void AddRoom(int number, float price) {
            roomsCollection.Add(new Room(number, price));

            AddEvent.Invoke($"Была добавлена комната {number}: {price}руб");
        }

        public void AddClient(string name) {
            for (short i = 0; i < clientCollection.Count; ++i) {
                if (clientCollection[i].Name.Equals(name)) {
                    Console.WriteLine("Клиент уже зарегистрирован!");
                    return;
                }
            }

            clientCollection.Add(new Сlient(name));
            AddEvent?.Invoke($"Был добавлен новый клиент: {name}");
        }

        public void BookRoom(string name, int number) {
            for (short i = 0; i < clientCollection.Count; ++i) {
                if (clientCollection[i].Name.Equals(name)) {
                    for (short j = 0; j < roomsCollection.Count; ++j) {
                        if (roomsCollection[j].Number.Equals(number)) {
                            if (roomsCollection[j].RoomIsFree) {
                                clientCollection[i].AddRooms(roomsCollection[j]);

                                roomsCollection[j].RoomIsFree = false;

                                BookEvent?.Invoke($"Комната {number} была зарегестрирована на клиента {name}");
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
