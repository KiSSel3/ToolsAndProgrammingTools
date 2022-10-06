namespace _153505_Kiselev_Lab3.Entities
{
    internal class Hotel
    {
        private Dictionary<int, Room> roomsCollection = new();
        
        private List<Client> clientsCollection = new();

        public delegate void EventHandler(string message);
        public EventHandler? AddEvent;
        public EventHandler? ErrorEvent;

        public void AddRoom(int number, int price)
        {
            if (!roomsCollection.ContainsKey(number))
            {
                roomsCollection.Add(number, new Room(price, number));
                AddEvent?.Invoke($"Была добавлена комната {number}: {price}руб");
            }
            else
            {
                ErrorEvent?.Invoke($"Комната {number} уже зарегистрирована!");
            }
        }

        public void AddClient(string name)
        {
            foreach (var client in clientsCollection)
            {
                if (client.Name.Equals(name))
                {
                    ErrorEvent?.Invoke($"Клиент {name} уже зарегистрирован!");
                    return;
                }
            }

            clientsCollection.Add(new Client(name));
            AddEvent?.Invoke($"Был добавлен новый клиент: {name}");
        }

        public void BookRoom(string name, int number)
        {
            foreach (var client in clientsCollection)
            {
                if (client.Name.Equals(name))
                {
                    if (roomsCollection.ContainsKey(number))
                    {
                        if (roomsCollection[number].RoomIsFree)
                        {
                            client.AddRoom(roomsCollection[number]);
                            roomsCollection[number].RoomIsFree = false;

                            AddEvent?.Invoke($"Клиент {name} занял комнату {number}");
                        }
                        else
                        {
                            ErrorEvent?.Invoke($"Комната {number} занята!");
                        }
                    }
                    else
                    {
                        ErrorEvent?.Invoke($"Комната {number} отсутствует!");
                    }

                    return;
                }
            }

            ErrorEvent?.Invoke($"Клиент {name} отсутствует!");
        }

        public float TotalCostReservedRooms()
        {
            var freeRoomCollection = from item in roomsCollection 
                                     where !item.Value.RoomIsFree 
                                     select item;

            float totalCost = 0;

            foreach (var room in roomsCollection)
            {
                totalCost += room.Value.Price;
            }

            return totalCost;
        }

        public List<Room> SortRooms()
        {
            var sortRooms = from item in roomsCollection 
                            orderby item.Value.Price 
                            select item.Value;

            return new List<Room>(sortRooms);
        }

        public string GetCostlyClient()
        {
            var costlyClient = from item in clientsCollection orderby item.CostOfLiving select item;

            return costlyClient.Last().Name;
        }

        public int CountClients(float price)
        {
            var countClients = (from item in clientsCollection where item.CostOfLiving > price select item).Count();

            return countClients;
        }

        public void RoomsByCost()
        {
            IEnumerable<(float Price,int Count)> roomsByCost = from item in roomsCollection 
                              group item.Value by item.Value.Price into gr
                              select (gr.Key, gr.Count());

            foreach (var price in roomsByCost)
            {
                Console.WriteLine($"Цена {price.Price} -----> {price.Count}");

                
            }
            
        }

        public void FreeRooms()
        {
            var freeRooms = from item in roomsCollection where item.Value.RoomIsFree select item.Value;

            foreach(var item in freeRooms)
            {
                Console.WriteLine($"Номер комнаты: {item.Number} || Цена: {item.Price}");
            }
        }

        public void ClientInfo()
        {
            foreach(var item in clientsCollection)
            {
                Console.WriteLine($"Клиент: {item.Name} || Цена: {item.CostOfLiving}");
            }
        }

        public void InfoRooms()
        {
            foreach(var item in roomsCollection)
            {
                var state = (item.Value.RoomIsFree) ? "Cвободна" : "Занята";
                Console.WriteLine($"Номер комнаты: {item.Value.Number} || Цена: {item.Value.Price}  || Состояние: {state}");
            }
        }
    }
}
