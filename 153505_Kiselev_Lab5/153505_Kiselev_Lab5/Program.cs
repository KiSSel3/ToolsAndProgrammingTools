using _153505_Kiselev_Lab5.Domain;
using Serializer;
using System.Collections.ObjectModel;

internal class Program
{
    private static void Main(string[] args)
    {
        Serializer.Serializer mySerializer     = new(); 
        List<Restaurant> collectionRestaurants = new();        

        collectionRestaurants.Add(new Restaurant(3, 1, 300, 500, false));
        collectionRestaurants.Add(new Restaurant(5, 1, 300, 500, false));
        collectionRestaurants.Add(new Restaurant(1, 1,  10,   5, false));
        collectionRestaurants.Add(new Restaurant(4, 1, 300, 600, false));
        collectionRestaurants.Add(new Restaurant(5, 1, 500, 200, false));
        collectionRestaurants.Add(new Restaurant(2, 1, 100,  10, false));

        Console.WriteLine("\n\t|~~~~~SerializeJSON~~~~~|");
        mySerializer.SerializeJSON(collectionRestaurants, "MyJson.json");

        var newCollectionRestaurantsJSON = mySerializer.DeSerializeJSON("MyJson.json");

        foreach (var item in newCollectionRestaurantsJSON)
        {
            Console.WriteLine(item.ShowRestaurantInfo());

        }

        Console.WriteLine("\n\t|~~~~~SerializeByLINQ~~~~~|");
        mySerializer.SerializeByLINQ(collectionRestaurants, "MySerializeByLINQ.xml");

        var newCollectionRestaurantsByLINQ = mySerializer.DeSerializeByLINQ("MySerializeByLINQ.xml");
        foreach (var item in newCollectionRestaurantsByLINQ)
        {
            Console.WriteLine(item.ShowRestaurantInfo());
        }

        Console.WriteLine("\n\t|~~~~~SerializeXML~~~~~|");
        mySerializer.SerializeXML(collectionRestaurants, "MyXML.xml");

        var newCollectionRestaurantsXML = mySerializer.DeSerializeXML("MyXML.xml");
        foreach (var item in newCollectionRestaurantsXML)
        {
            Console.WriteLine(item.ShowRestaurantInfo());
        }
    }
}