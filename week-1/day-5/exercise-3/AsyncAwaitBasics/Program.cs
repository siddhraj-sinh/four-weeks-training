using System.Diagnostics;
namespace AsyncAwaitBasics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Call PerformCalculations and measure time taken using Stopwatch
            await PerformCalculations(5);
            Console.ReadLine();
        }

        static async Task SimulateLongRunningTask(int delayInSeconds)
        {
            // Implement long-running task simulation
            Console.WriteLine("long running task started....");
            await Task.Delay(delayInSeconds*1000);
            Console.WriteLine("long running task completed....");
        }

        static async Task PerformCalculations(int numberOfTasks)
        {
            // Start long-running tasks concurrently and wait for them to complete
            Console.WriteLine($"Performing {numberOfTasks} calculations...");

            Stopwatch stopwatch = Stopwatch.StartNew();

            // Start long-running tasks concurrently
            Task[] tasks = new Task[numberOfTasks];
            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = SimulateLongRunningTask(3); // Example delay of 3 seconds
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);

            stopwatch.Stop();

            Console.WriteLine($"All tasks completed in {stopwatch.ElapsedMilliseconds} ms.");


        }
    }
}