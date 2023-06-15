namespace LinqToObjectsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "John", Age = 25, Country = "USA" },
                new Person { Name = "Jane", Age = 30, Country = "Canada" },
                new Person { Name = "Mark", Age = 28, Country = "USA" },
                new Person { Name = "Emily", Age = 22, Country = "Australia" },
                new Person { Name = "Peter", Age = 31, Country = "Australia" }
            };

            Console.WriteLine("Get all people from USA:");
            var usaCitizens = people.Where(p => p.Country == "USA").ToList<Person>();

            
            foreach (Person person in usaCitizens)
            {
                Console.WriteLine(person.Name);
            }

            var above30 = people.Where(p => p.Age > 30).ToList<Person>();
            Console.WriteLine("Get all people above 30:");
            foreach (Person person in above30) { Console.WriteLine(person.Name); }

            var pepoleInAscOrder = people.OrderBy(p => p.Name).ToList<Person>();
            Console.WriteLine("Sort people by name:");
            foreach (Person person in pepoleInAscOrder){ Console.WriteLine(person.Name); }

            var peopleNameAndCountry = people.Select(p => new { p.Name, p.Country });

            Console.WriteLine("Names and Countries of all people:");
            foreach (var person in peopleNameAndCountry)
            {
                Console.WriteLine($"Name: {person.Name}, Country: {person.Country}");
            }

            Console.ReadLine();
            //Write queries using LINQ for following operations
            //1. Get all people from USA
            //2. Get all people above 30
            //3. Sort people by name
            //4. Project/Select only Name and Country of all people

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
}