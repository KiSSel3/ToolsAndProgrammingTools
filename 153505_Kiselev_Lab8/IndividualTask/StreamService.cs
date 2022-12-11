using System.Text.Json;

namespace IndividualTask
{
    public class StreamService<T>
    {
        private Semaphore semaphore = new Semaphore(1,1);
        public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress)
        {
            progress.Report($"\nПоток {Thread.CurrentThread.ManagedThreadId} запущен\n");

            semaphore.WaitOne();

            progress.Report($"\nПоток {Thread.CurrentThread.ManagedThreadId} начал запись данных в Stream\n");

            var task1 = JsonSerializer.SerializeAsync(stream, data);
            var task2 =  GetPercentageOfCompletion(progress);

            Task.WaitAll(task1, task2);

            progress.Report($"\nПоток {Thread.CurrentThread.ManagedThreadId} закончил запись данных в Stream\n");

            semaphore.Release();
        }

        public async Task CopyFromStreamAsync(Stream stream, string fileName, IProgress<string> progress)
        {
            progress.Report($"\nПоток {Thread.CurrentThread.ManagedThreadId} запущен\n");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            semaphore.WaitOne();

            progress.Report($"\nПоток {Thread.CurrentThread.ManagedThreadId} начал запись данных в Файл\n");

            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                stream.Position = 0;

                await stream.CopyToAsync(fileStream);
                await GetPercentageOfCompletion(progress);

            }
            progress.Report($"\nПоток {Thread.CurrentThread.ManagedThreadId} закончил запись данных в Файл\n");

            semaphore.Release();
        }

        public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var data = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(fileStream);

                return data.Where(filter).Count();
            }
        }

        private async Task GetPercentageOfCompletion(IProgress<string> progress)
        {
            for (int i = 0; i <= 100; i += 5)
            {
                await Task.Delay(100);
                progress.Report($"\rПроцент выполнения: {i} %");
            }
        }
    }
}
