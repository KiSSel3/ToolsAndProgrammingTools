using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Kiselev_Lab6
{
    [Serializable]
    public class Employee
    {
        public Employee() { }

        public Employee(string name, int experience, bool isOnVacation) => (Name, Experience, IsOnVacation) = (name, experience, isOnVacation);

        public string Name { get; set; }
        public int Experience { get; set; }
        public bool IsOnVacation { get; set; }

        public override string ToString()
        {
            return "Name: " + Name +
                "\nОпыт: " + Experience.ToString() +
                "\nВ отпуске: " + IsOnVacation.ToString();
        }
    }
}
