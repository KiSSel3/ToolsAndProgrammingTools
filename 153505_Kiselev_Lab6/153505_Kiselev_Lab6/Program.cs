using System.Reflection;
//BindingFlags - DeclaredOnly
internal class Program
{
    private static void Main(string[] args)
    {
        Assembly assembly = Assembly.LoadFrom("D:\\Programming\\SecondCourse\\ToolsAndProgrammingTools\\153505_Kiselev_Lab6\\MyLib\\bin\\Debug\\net6.0\\MyLib.dll");

        //Type[] types = assembly.GetTypes();
        //Type? typeEmployee = types[3];

   /*     if (typeEmployee is not null)
        {*/
            object Employee = Activator.CreateInstance("D:\\Programming\\SecondCourse\\ToolsAndProgrammingTools\\153505_Kiselev_Lab6\\MyLib\\bin\\Debug\\net6.0\\MyLib.dll","Employee");

             //List <typeEmployee> employees;
/*        }
        else
        {
            Console.WriteLine("Ошибка поключения библиотеки!");
        }*/
/*
        foreach (var t in types)
        {
            Console.WriteLine(t.Name);
        }*/

    }
}