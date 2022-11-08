using System.Text.Json;

namespace MyLib
{
    public class FileService : IFileService<Employee>
    {
        IEnumerable<Employee> IFileService<Employee>.ReadFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize(fileStream, typeof(List<Employee>)) as List<Employee>;
            }
        }

        void IFileService<Employee>.SaveData(IEnumerable<Employee> data, string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fileStream, data);
            }
        }
    }
}