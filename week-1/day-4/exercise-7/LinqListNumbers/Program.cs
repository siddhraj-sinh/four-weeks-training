namespace LinqListNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of integers
            List<int> numbers = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

            // Use LINQ to perform the following operations:
            
            // 1. Find all even numbers
            Console.WriteLine("1. Find all even numbers");
            var evenNumbers = numbers.Where(n=>n%2==0).ToList();
            foreach(int n in evenNumbers) { Console.WriteLine(n); }
            
            Console.WriteLine("2. Find all numbers greater than a specific value (e.g., 20)");
            // 2. Find all numbers greater than a specific value (e.g., 20)
            var numGT20 = numbers.Where(n=> n>20).ToList(); 
            foreach(int n in numGT20) {  Console.WriteLine(n); }
            
            // 3. Calculate the sum of all numbers
            Console.WriteLine("3. Calculate the sum of all numbers");
            var sum = numbers.Sum();
            Console.WriteLine(sum);

            // 4. Calculate the average of all numbers
            Console.WriteLine("4. Calculate the average of all numbers");
            var avg = numbers.Average();
            Console.WriteLine(avg);
            // 5. Find the minimum and maximum values in the list
            Console.WriteLine("5. Find the minimum and maximum values in the list");
            var min = numbers.Min();
            var max = numbers.Max();
            Console.WriteLine("Min: "+min);
            Console.WriteLine("Max: "+max);
            Console.ReadLine();
        }
    }
}