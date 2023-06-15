using System.Xml.Linq;

namespace LibraryManagement
{
    internal class Program
    {
        // Initialize collections for books, authors, and borrowers
        static List<Book> books = new List<Book>();
        static List<Author> authors = new List<Author>();
        static List<Borrower> borrowers = new List<Borrower>();
        static void Main(string[] args)
        {
            
            // Main program loop
            while (true)
            {
                DisplayMenu();

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    // Add cases for each menu option
                    case 1:
                        // Add a book
                        AddBook();
                        break;
                    case 2:
                        break;
                    case 3:
                        DeleteBook();
                        break;
                    case 4:
                        ListAllBooks();
                        break;
                    // ...
                    case 16:
                        // Filter books by status
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            // Display the menu options
            Console.WriteLine("Welcome to the Library Management System!\n");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Update a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. List all books");
            // ...Add Other options here
            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }

        static void AddBook() {
            Console.WriteLine("Enter the book title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the author's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the author's last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ener the author's date of birth (YYY--MM-DD): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the publication year: ");
            int publicationYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Is the book available? (yes/no): ");
            bool isAvailable = Console.ReadLine().ToLower() == "yes" ? true : false;


            Author author = new Author { FirstName=firstName,LastName=lastName, DateOfBirth=dateOfBirth };  
            Book book = new Book { Title=title,Author=author,PublicationYear=publicationYear,IsAvailable=isAvailable};
            books.Add(book);

        }

        static void DeleteBook() {

            Console.WriteLine("Write title of the book that you want to delete: ");
            string title = Console.ReadLine();

            var book = books.Find(b => b.Title == title);

            if (book != null)
            {
                books.Remove(book);
            }
        }

        static void ListAllBooks() {
            foreach (Book b in books) {
                Console.WriteLine(b.ToString());
            }
        }
    }

    // Class definitions
    class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}\nAuthor {Author.FirstName} {Author.LastName}\n Date of Birth: {Author.DateOfBirth}\nPublication Year: {PublicationYear}\nIsAvailable: {IsAvailable}";
        }
    }

    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    class Borrower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}