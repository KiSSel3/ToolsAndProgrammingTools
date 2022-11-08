using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Kiselev_Lab5.Domain
{
    public interface ISerializer
    {
        IEnumerable<Restaurant> DeSerializeByLINQ(string fileName);
        IEnumerable<Restaurant> DeSerializeXML(string fileName);
        IEnumerable<Restaurant> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Restaurant> data, string fileName);
        void SerializeXML(IEnumerable<Restaurant> data, string fileName);
        void SerializeJSON(IEnumerable<Restaurant> data, string fileName);
    }
}
