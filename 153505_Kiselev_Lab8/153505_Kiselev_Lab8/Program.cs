using IndividualTask;

public class Program
{
    private async static Task Main(string[] args)
    {
        StreamService<Patient> streamService = new StreamService<Patient>();
        MemoryStream memoryStream = new();

        IProgress<string> progress = new Progress<string>(message => Console.Write(message));

        Random random = new();

        List<string> diagnoses = new()
        {
            "Schizophrenia",
            "Manic depression",
            "Neurosis",
            "Paranoia",
            "Migraine",
            "Epilepsy",
        };

        List<Patient> patients = new();

        for(int i = 0; i < 1000; ++i)
        {
            patients.Add(new Patient(i, $"Имя{i}", diagnoses[random.Next(0, 5)]));
        }

        var writeTask = streamService.WriteToStreamAsync(memoryStream, patients, progress);
        await Task.Delay(200);
        var copyTask  = streamService.CopyFromStreamAsync(memoryStream, "Patients.json", progress);

        Task.WaitAll(writeTask, copyTask);

        Console.WriteLine($"\nКоличество пациентов с болезнью {diagnoses[0]}: {await streamService.GetStatisticsAsync("Patients.json",(item)=>item.Diagnosis == diagnoses[0])}");
    }

    
}