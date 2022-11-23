using _153505_Kiselev_Lab6;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee("Andrey",  8, false),
            new Employee("Arsenii", 5, true),
            new Employee("Maxim",   7, true),
            new Employee("Pasha",   8, false),
            new Employee("Nastya",  8, false),
        };

        Console.WriteLine("\tИсходные данные:");
        foreach (var item in employees)
        {
            Console.WriteLine(item);
        }

        Assembly assembly = Assembly.LoadFrom("D:\\Programming\\SecondCourse\\ToolsAndProgrammingTools\\153505_Kiselev_Lab6\\MyLib\\bin\\Debug\\net6.0\\MyLib.dll");
        var myLibClassType = assembly.GetType("MyLib.FileService`1").MakeGenericType(typeof(Employee));       

        if (myLibClassType is not null)
        {
            var myLibClass = Activator.CreateInstance(myLibClassType);

            var SaveData = myLibClassType.GetMethod("SaveData");
            var ReadFile = myLibClassType.GetMethod("ReadFile");

            SaveData?.Invoke(myLibClass, new object[] { employees, "Employees.json" });
            var newEmployees = ReadFile.Invoke(myLibClass, new object[] { "Employees.json" });

            Console.WriteLine("\n\tДанные после сериализации:");
            foreach (var item in newEmployees as List<Employee>)
            {
                Console.WriteLine(item);
            }
        }
    }
}