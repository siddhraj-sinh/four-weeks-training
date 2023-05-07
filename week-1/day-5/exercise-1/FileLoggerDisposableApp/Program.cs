namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly
        }
    }

    class FileLogger : IDisposable
    {
        private StreamWriter _writer;

        public FileLogger(string filePath)
        {
            // Initialize StreamWriter instance
        }

        public void Dispose()
        {
            // Implement IDisposable pattern
        }

        public void Log(string message)
        {
            // Write message to the file
        }
    }
}