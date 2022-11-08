namespace MyLib
{
    [Serializable]
    public class Employee
    {
        Employee() { }

        Employee(string name, int experience, bool isOnVacation) => (Name, Experience, IsOnVacation) = (name, experience, isOnVacation);

        public string Name { get; set; }
        public int Experience { get; set; }
        public bool IsOnVacation { get; set; }

    }
}