using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153505_Kiselev_Lab2.Collection;


namespace _153505_Kiselev_Lab2.Entities
{
    internal class Journal
    {
        private MyCustomCollection<string> pastEvents = new MyCustomCollection<string>();

        public void AddEvents(string message)
        {
            pastEvents.Add(message);
        }

        public void PrintPastEvent()
        {
            foreach(var item in pastEvents){
                Console.WriteLine(item);
            }
        }
    }
}
