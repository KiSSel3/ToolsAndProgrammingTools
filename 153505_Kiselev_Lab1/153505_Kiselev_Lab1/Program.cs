using _153505_Kiselev_Lab1.Collection;
using _153505_Kiselev_Lab1.Entities;
internal class Program {
    private static void Main(string[] args) {
        Hotel hotel = new Hotel();

        hotel.AddRoom(1, 100);
        hotel.AddRoom(2, 100);
        hotel.AddRoom(3, 100);

        Console.WriteLine("\nИнформвация о номерах:");
        hotel.InfoRooms();

        Console.WriteLine("\n----------------\n");

        hotel.AddClient("Kiselev");
        hotel.AddClient("Kiseleva");
        hotel.AddClient("Ivanov");

        Console.WriteLine("\nИнформвация о клиентах:");
        hotel.ClientInfo();

        Console.WriteLine("\n----------------\n");

        hotel.BookRoom("RRR", 1);

        Console.WriteLine("\n----------------\n");

        hotel.BookRoom("Kiselev", 1);
        hotel.BookRoom("Kiselev", 2);

        Console.WriteLine("\nИнформвация о клиентах:");
        hotel.ClientInfo();

        Console.WriteLine("\n----------------\n");

        Console.WriteLine("\nСвободные номера:");
        hotel.FreeRooms();

        Console.WriteLine("\n----------------\n");

        hotel.BookRoom("Kiseleva", 3);

        Console.WriteLine("\nИнформвация о клиентах:");
        hotel.ClientInfo();

        Console.WriteLine("\n----------------\n");
        hotel.BookRoom("Ivanov", 3);

        Console.WriteLine("\n----------------\n");
        hotel.AddClient("Kiseleva");

        //TestCollection();
    }

    /*private static void TestCollection() {
        MyCustomCollection<int> collection = new MyCustomCollection<int>();

        collection.Add(12);
        collection.Add(0);
        collection.Add(55);
        collection.Add(234);
        collection.Add(12234);

        for (short i = 0; i < collection.Count; ++i) {
            Console.WriteLine(collection.Current());
            collection.Next();
        }

        Console.WriteLine("");

        collection.Remove(0);
        for (short i = 0; i < collection.Count; ++i) {
            Console.WriteLine(collection.Current());
            collection.Next();
        }

        Console.WriteLine("");

        collection.RemoveCurrent();
        for (short i = 0; i < collection.Count; ++i) {
            Console.WriteLine(collection.Current());
            collection.Next();
        }

        Console.WriteLine("");

        for (short i = 0; i < collection.Count; ++i) {
            Console.WriteLine(collection[i]);
        }

        Console.WriteLine("");

        collection.Remove(999);

        for (short i = 0; i < collection.Count; ++i) {
            collection[i] = 0;
            Console.WriteLine(collection[i]);
        }
    }*/
}