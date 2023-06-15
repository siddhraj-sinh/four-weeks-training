namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\siddharaj\local\week-1\day-5\exercise-1\FileLoggerDisposableApp\log.txt";
            // Use FileLogger and dispose of it properly
            using (var logger = new FileLogger(fileName))
            {
                logger.Log("Log entry 1");
                logger.Log("Log entry 2");
                logger.Log("Log entry 3");
            }
        }
    }


    class FileLogger : IDisposable
    {
        private StreamWriter _writer;

        public FileLogger(string filePath)
        {
            // Initialize StreamWriter instance
            _writer = new StreamWriter(filePath);
        }

        public void Dispose()
        {
            // Implement IDisposable pattern

            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_writer!=null) {
                    
                    _writer.Dispose();
                    _writer = null;
                }
            }
        }
        public void Log(string message)
        {
            // Write message to the file
            if (_writer == null)
            {
                throw new ObjectDisposedException("FileLogger", "The logger has been disposed.");
            }
            Console.WriteLine(message);
            _writer.WriteLine(message);
        }
    }
}