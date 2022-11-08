using System.Runtime.Serialization;

namespace _153505_Kiselev_Lab5.Domain
{
    [Serializable]
    public class Restaurant
    {
        public Restaurant() { }
        public Restaurant(int numberOfStars = 0, int Number = 1, int Width = 100, int Height = 100, bool Works = false)
        {
            this.numberOfStars = numberOfStars;

            KitchenRestaurant = new Kitchen(Number, Width, Height, Works);
        }

        public Kitchen kitchenRestaurant = new();
        public Kitchen KitchenRestaurant {
            get
            {
                return kitchenRestaurant;
            }

            set
            {
                kitchenRestaurant = value;
            }
        }

        public string ShowRestaurantInfo()
        {
            return "\n Ресторан " + numberOfStars.ToString() + " звёзд." +
                   "\n Номер кухни:" + KitchenRestaurant.Number.ToString() +
                   "\n Размеры кухни: " + KitchenRestaurant.Width.ToString() + "x" + KitchenRestaurant.Height.ToString() +
                   "\n Работает ли кухня: " + KitchenRestaurant.Works.ToString();
        }

        public int numberOfStars = 0;
        public int NumberOfStars
        {
            get
            {
                return numberOfStars;
            }
            set
            {
                if(value <= 5 && value >= 0)
                {
                    numberOfStars = value;
                }
                else
                {
                    numberOfStars = 0;
                }
            }
        }

        public void OpenRestaurant() => KitchenRestaurant.Works = true;
        public void CloseRestaurant() => KitchenRestaurant.Works = false;
    }
}