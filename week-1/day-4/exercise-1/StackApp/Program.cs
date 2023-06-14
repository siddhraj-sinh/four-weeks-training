namespace StackApp
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Stack<int> intStack = new Stack<int>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            Console.WriteLine(intStack.Pop()); // Output: 3
            Console.WriteLine(intStack.Pop()); // Output: 2
            Console.WriteLine(intStack.IsEmpty()); // Output: False

            Stack<String> stack = new Stack<String>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            Console.WriteLine(stack.Pop()); // output: C

            Stack<Person> personStack = new Stack<Person>();
            personStack.Push(new Person("John", 25));
            personStack.Push(new Person("Jane", 30));
            Console.WriteLine("Popped item: " + personStack.Pop());
            Console.ReadLine();
        }

    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"{Name} : {Age}";
        }


    }
}