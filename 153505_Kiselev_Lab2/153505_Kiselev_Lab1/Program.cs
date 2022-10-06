using _153505_Kiselev_Lab2.Collection;
using _153505_Kiselev_Lab2.Entities;
internal class Program
{
    private static void Main(string[] args)
    {
        Journal journal = new Journal();
        Hotel hotel = new Hotel();

        hotel.AddEvent += journal.AddEvents;
        hotel.BookEvent += (string message) => Console.WriteLine(message);

        hotel.AddRoom(1, 100);
        hotel.AddRoom(2, 100);
        hotel.AddRoom(3, 100);

        Console.WriteLine("\nИнформвация о номерах:");
        hotel.InfoRooms();

        Console.WriteLine("\n----------------\n");

        hotel.AddClient("Kiselev");
.\        hotel.AddClient("Kiseleva");
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

        journal.PrintPastEvent();

        //Проверка исключений
        try
        {
            MyCustomCollection<int> collection = new();
            collection.Add(5);
            collection.Remove(6);

        }
        catch (MyException exception)
        {
            Console.WriteLine($"Во время выполнения было выброшено собственное исключение:\n {exception.Message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Во время выполнения было выброшено исключение:\n {exception.Message}");
        }
    }
}