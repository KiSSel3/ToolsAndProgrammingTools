using _153505_Kiselev_Lab4.Entities;
using _153505_Kiselev_Lab4.Service;
using System.Collections.ObjectModel;

internal class Program
{
    private static void Main(string[] args)
    {
        FileService fileService = new FileService();

        Collection<ArtObject> myGallery = new();

        myGallery.Add(new ArtObject("Mona Lisa", 1519, true));
        myGallery.Add(new ArtObject("Girl with a Pearl Earring", 1665, true));
        myGallery.Add(new ArtObject("The Starry Night", 1889, true));
        myGallery.Add(new ArtObject("The Kiss", 1908, false));
        myGallery.Add(new ArtObject("The Birth of Venus", 1486, false));
        myGallery.Add(new ArtObject("Arrangement in Grey and Black No. 1", 1871, true));


        //Сохранение коллекции
        fileService.SaveData(myGallery, "Gallery.bin");

        //Изменение названия файла
        try
        {
            File.Move("Gallery.bin", "NewGallery.bin");
        }
        catch (IOException)
        {
            File.Delete("NewGallery.bin");
            File.Move("Gallery.bin", "NewGallery.bin");
        }

        //Загрузка коллекции из нового файла
        List<ArtObject> newMyGallery = new List<ArtObject>(fileService.ReadFile("NewGallery.bin"));

        Console.WriteLine("\n\tВывод на экран коллекции");
        foreach (var item in newMyGallery)
        {
            Console.WriteLine($"{item.Name}  || {item.DateOfCreation} || {item.Available}");
        }

        //Сортировка коллекции по полю Name
        var myCustomComparer = new MyCustomComparer();

        var sortNewMyGallery = newMyGallery.OrderBy(item => item,
            myCustomComparer);

        Console.WriteLine("\n\tВывод на экран отсортированной по имени коллекции");
        foreach (var item in sortNewMyGallery)
        {
            Console.WriteLine($"{item.Name}  || {item.DateOfCreation} || {item.Available}");
        }

        //Сортировка коллекции по полю DateOfCreation
        sortNewMyGallery = newMyGallery.OrderBy((item) => { return item.DateOfCreation; });

        Console.WriteLine("\n\tВывод на экран отсортированной по году коллекции");
        foreach (var item in sortNewMyGallery)
        {
            Console.WriteLine($"{item.Name}  || {item.DateOfCreation} || {item.Available}");
        }
    }
}