using _153505_Kiselev_Lab5.Domain;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serializer
{
    public class Serializer : ISerializer
    {
        public IEnumerable<Restaurant> DeSerializeByLINQ(string fileName)
        {
            XDocument xDocument = XDocument.Load(fileName);
            var restaurants = xDocument.Element("Restaurants");

            if (restaurants is not null)
            {
                foreach (var restaurant in restaurants.Elements("Restaurant"))
                {
                    var kitchen = restaurant.Element("Kitchen");

                    yield return new Restaurant(Convert.ToInt32(restaurant.Element("RestaurantStar")?.Value),
                                                Convert.ToInt32(kitchen.Element("Number")?.Value),
                                                Convert.ToInt32(kitchen.Element("Width")?.Value),
                                                Convert.ToInt32(kitchen.Element("Height")?.Value),
                                                Convert.ToBoolean(kitchen.Element("Works")?.Value));
                }
            }


        }

        public IEnumerable<Restaurant> DeSerializeJSON(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize(fileStream, typeof(List<Restaurant>)) as List<Restaurant>;
            }
        }

        public IEnumerable<Restaurant> DeSerializeXML(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Restaurant>));

            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return xmlSerializer.Deserialize(fileStream) as List<Restaurant>;
            }
        }

        public void SerializeByLINQ(IEnumerable<Restaurant> data, string fileName)
        {
            XDocument xDocument = new();
            XElement restaurants = new XElement("Restaurants");

            foreach (var item in data)
            {
                XElement restaurant = new XElement("Restaurant");
                XElement restaurantStar = new XElement("RestaurantStar", item.NumberOfStars);

                XElement kitchen = new XElement("Kitchen");

                XElement kitchenNumber = new XElement("Number", item.KitchenRestaurant.Number);
                XElement kitchenWidth = new XElement("Width", item.KitchenRestaurant.Width);
                XElement kitchenHeight = new XElement("Height", item.KitchenRestaurant.Height);
                XElement kitchenWorks = new XElement("Works", item.KitchenRestaurant.Works);

                kitchen.Add(kitchenNumber);
                kitchen.Add(kitchenWidth);
                kitchen.Add(kitchenHeight);
                kitchen.Add(kitchenWorks);

                restaurant.Add(restaurantStar);
                restaurant.Add(kitchen);

                restaurants.Add(restaurant);
            }
            xDocument.Add(restaurants);
            xDocument.Save(fileName);
        }

        public void SerializeJSON(IEnumerable<Restaurant> data, string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, data);
            }
        }

        public void SerializeXML(IEnumerable<Restaurant> data, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Restaurant>));

            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, data);
            }
        }
    }
}