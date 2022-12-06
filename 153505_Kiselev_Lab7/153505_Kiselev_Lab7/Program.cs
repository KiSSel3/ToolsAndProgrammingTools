using _153505_Kiselev_Lab7;

internal class Program
{
    private static void Main(string[] args)
    {
        Integral integral = new Integral();
        integral.LeadTime += (message) => Console.WriteLine(message);
        integral.Progress += (message) => Console.Write(message);

        Thread thread1 = new Thread(new ParameterizedThreadStart(integral.SinX!));
        Thread thread2 = new Thread(new ParameterizedThreadStart(integral.SinX!));
        Thread thread3 = new Thread(new ParameterizedThreadStart(integral.SinX!));
        Thread thread4 = new Thread(new ParameterizedThreadStart(integral.SinX!));
        Thread thread5 = new Thread(new ParameterizedThreadStart(integral.SinX!));

/*        thread1.Priority = ThreadPriority.Highest;
        thread2.Priority = ThreadPriority.Lowest;*/

        thread1.Start((0.0, 1.0, 100000000));
        thread2.Start((0.0, 1.0, 100000000));
        thread3.Start((0.0, 1.0, 100000000));
        thread4.Start((0.0, 1.0, 100000000));
        thread5.Start((0.0, 1.0, 100000000));

        Integral.semaphore.Release(2);
    }
}

