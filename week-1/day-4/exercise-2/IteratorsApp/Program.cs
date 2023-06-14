namespace IteratorsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fibonacci = FibonacciSequence().Take(10);
            foreach (int number in fibonacci)
            {
                Console.WriteLine(number);
            }

            //Console.WriteLine("Hello World");
            Console.ReadLine();
        }
        // https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
        public static IEnumerable<int> FibonacciSequence()
        {
            int first = 0;
            int second = 1;

            yield return first;
            yield return second;

            while (true)
            {
                int next = first + second;
                yield return next;

                first = second;
                second = next;
            }
        }
    }
}