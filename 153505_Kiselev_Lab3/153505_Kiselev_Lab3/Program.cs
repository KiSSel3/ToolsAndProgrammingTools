using _153505_Kiselev_Lab3.Entities;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Hotel hotel = new Hotel();

        hotel.AddEvent += (string message) => { Console.WriteLine($"\tПроизошло действие:\n  {message}\n"); };
        hotel.ErrorEvent += (string message) => { Console.WriteLine($"\tОшибка действия:\n  {message}\n"); };

        hotel.AddClient("Kiseleva");
        hotel.AddClient( "Kiselev");
        hotel.AddClient(  "Egorov");
        hotel.AddClient(  "Ivanov");
        hotel.AddClient(  "Ivanov");

        hotel.AddRoom(1, 100);
        hotel.AddRoom(2, 100);
        hotel.AddRoom(3,  50);
        hotel.AddRoom(4, 200);
        hotel.AddRoom(5, 500);
        hotel.AddRoom(5, 500);

        hotel.BookRoom("Kiselev",  5);
        hotel.BookRoom("Kiselev",  4);
        hotel.BookRoom("Kiseleva", 2);
        hotel.BookRoom("Kiseleva", 1);
        hotel.BookRoom("Egorov",   3);
        hotel.BookRoom("Ivanov",   3);

        Console.WriteLine("\n\nИнформация о клиентах:");
        hotel.ClientInfo();

        hotel.RoomsByCost();

        Console.WriteLine($"Общая стоимость всех забранированных номеров: {hotel.TotalCostReservedRooms()}");

        {
            var rooms = hotel.SortRooms();

            foreach(var item in rooms)
            {
                Console.WriteLine($"Номер: {item.Number} Ценa: {item.Price}");
            }
        }

        Console.WriteLine($"\nКлиент, заплативший максимальную сумму: {hotel.GetCostlyClient()}");

        Console.WriteLine($"\nКоличество клиентов, заплативших больше 100: {hotel.CountClients(100)}");

    }
}
