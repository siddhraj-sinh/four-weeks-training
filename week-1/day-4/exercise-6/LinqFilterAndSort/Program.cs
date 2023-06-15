namespace LinqFilterAndSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Person objects
            // Use LINQ to filter and sort the list
            // Print the filtered and sorted list of people to the console

            List<Person> pepole = new List<Person>()
            {
                new Person() { FirstName = "Siddhraj", LastName = "Rathod", Age = 18 },
                new Person() { FirstName = "Karnik", LastName = "Patel", Age = 30 },
                new Person() { FirstName = "Vandan", LastName = "Patel", Age = 25 },
                new Person() { FirstName = "Arsh", LastName = "Shah", Age = 15 },
                new Person() { FirstName = "Nimit", LastName = "Trevadiya", Age = 20 },
            };
            Console.WriteLine("Pepole above 18 or 18: ");
            var pepoleAbove18 = pepole.Where(p=>p.Age>=18).ToList<Person>();
            foreach (Person person in pepoleAbove18) { Console.WriteLine(person.FirstName); }

            Console.WriteLine("Sorted List: ");

            var sortedPepoleList = pepoleAbove18.OrderBy(p=>p.LastName).ThenBy(p=>p.FirstName);
            foreach (Person person in sortedPepoleList) { Console.WriteLine(person.FirstName + person.LastName); }
            Console.ReadLine();
        }
    }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

        }
    }