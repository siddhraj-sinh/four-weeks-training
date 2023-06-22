using System.Runtime.CompilerServices;
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
                        //update a book
                        UpdateBook();
                        break;
                    case 3:
                        //Delete a book
                        DeleteBook();
                        break;
                    case 4:
                        //list all book
                        ListAllBooks();
                        break;
                    case 5:
                        //add author
                        AddAuthor();
                        break;
                    case 6:
                        //update author
                        UpdateAuthor();
                        break;
                    case 7:
                        //delete author
                        DeleteAuthor();
                        break;
                    case 8:
                        //list author
                        ListAllAuthor();
                        break;
                    case 9:
                        //add borrower
                        AddBorrower();
                        break;
                    case 10:
                        //Update borrowe
                        UpdateBorrower();
                        break;
                    case 11:
                        //delete borrower
                        DeleteBorrower();
                        break;
                   case 12:
                        //list borrower
                        ListAllBorrower();
                        break;
                    case 13:
                        //register book to a borrower
                        BorrowBook();
                        break;
                    case 14:
                        //list all borrowed books
                        ListAllBorrowedBooks();
                        break;
                    case 15:
                        //search books
                        SearchBooks();
                        break;
                    case 16:
                        // Filter books by status
                        FilterBookByStatus();
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
            Console.WriteLine("********Welcome to the Library Management System!*******\n");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Update a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. List all books");
            Console.WriteLine("5. Add a author");
            Console.WriteLine("6. Update a author");
            Console.WriteLine("7. Delete a author");
            Console.WriteLine("8. List all authors");
            Console.WriteLine("9. Add a borrower");
            Console.WriteLine("10. Update a borrower");
            Console.WriteLine("11. Delete a borrower");
            Console.WriteLine("12. List all borrowers");
            Console.WriteLine("13. Borrow a book");
            Console.WriteLine("14. List all borrowed books");
            Console.WriteLine("15. Search books");
            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }

        static void AddBook() {
            Console.WriteLine("Enter the book title:");
            string title = Console.ReadLine();
            // Check if the book with the given title already exists
            if (books.Any(book => book.Title == title))
            {
                Console.WriteLine("A book with the given title already exists in the library.");
                return;
            }
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
            Console.WriteLine("Book added successfully..!");
            Console.WriteLine();

        }
        static void UpdateBook() {

            Console.WriteLine("Write title of the book that you want to update: ");
            string title = Console.ReadLine();
            var book = books.Find(b => b.Title == title);

            if (book != null)
            {
                Console.WriteLine("Enter the updated title (or press enter to keep the existing title):");
                string updatedTitle = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedTitle))
                {
                    book.Title = updatedTitle;
                }

                Console.WriteLine("Enter the updated author's first name (or press enter to keep the existing first name):");
                string updatedFirstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedFirstName))
                {
                    book.Author.FirstName = updatedFirstName;
                }

                Console.WriteLine("Enter the updated author's last name (or press enter to keep the existing last name):");
                string updatedLastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedLastName))
                {
                    book.Author.LastName = updatedLastName;
                }

                Console.WriteLine("Enter the updated publication year (or press enter to keep the existing publication year):");
                string updatedPublicationYearString = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedPublicationYearString))
                {
                    int updatedPublicationYear;
                    if (int.TryParse(updatedPublicationYearString, out updatedPublicationYear))
                    {
                        book.PublicationYear = updatedPublicationYear;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Publication year not updated.");
                    }
                }

                Console.WriteLine("Enter the updated availability status (true/false) (or press enter to keep the existing status):");
                string updatedAvailabilityString = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedAvailabilityString))
                {
                    bool updatedAvailability;
                    if (bool.TryParse(updatedAvailabilityString, out updatedAvailability))
                    {
                        book.IsAvailable = updatedAvailability;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Availability status not updated.");
                    }
                }

                Console.WriteLine("Book updated successfully!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Book with given title doesn't exists..!");
                Console.WriteLine();
            }

        }
        static void DeleteBook() {

            Console.WriteLine("Write title of the book that you want to delete: ");
            string title = Console.ReadLine();

            var book = books.Find(b => b.Title == title);

            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"{title} remove from library sucessfully..!");
            }
            else
            {
                Console.WriteLine("Book with this title doesn't exists..!");
            }
            Console.WriteLine();
        }

        static void ListAllBooks() {
            if(books.Count() == 0)
            {
                Console.WriteLine("No books available in library..!");
            }
            foreach (Book b in books) {
                Console.WriteLine(b.ToString());
                Console.WriteLine();

            }
            Console.WriteLine();
        }

        static void FilterBookByStatus() {

            Console.WriteLine("Enter the availability status (true/false):");
            string userInput = Console.ReadLine();
            bool value = userInput.ToLower() == "true" ? true : false;


            var book = books.FindAll(b => b.IsAvailable == value);
            if (book != null)
            {
                Console.WriteLine("Filtered books: ");
                foreach (Book b in book)
                {
                    Console.WriteLine(b.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Not found..!!");
            }
            Console.WriteLine();
        }

        static void BorrowBook() {
            Console.WriteLine("Enter the title of book that you want to borrow: ");
            string title = Console.ReadLine() ;
            var book = books.Find(b => b.Title == title);
            if (book != null)
            {
                if (book.IsAvailable)
                {
                    Console.WriteLine("Enter your first name: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter your last name: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter your email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter your phone number: ");
                    string phoneNumber = Console.ReadLine();
                    Borrower borrower = new Borrower { FirstName=firstName, LastName=lastName, Email=email,PhoneNumber=phoneNumber};
                    book.IsAvailable = false;
                    Console.WriteLine("Book borrowed succesfully..!");
                    borrowers.Add(borrower);
                }
                else
                {
                    Console.WriteLine("The book you want is not available..!");
                }
            }
            Console.WriteLine();
        }
        static void ListAllBorrowedBooks()
        {
            var borrowedBooks = books.Where(b => b.IsAvailable == false);
            if (borrowedBooks != null)
            {
                foreach (var b in borrowedBooks)
                {
                    Console.WriteLine(b.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No books is borrowed..!");
            }
            Console.WriteLine();
        }


        //Add author
        static void AddAuthor() {
            Console.WriteLine("Enter the author's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the author's last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ener the author's date of birth (YYY--MM-DD): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
           
            if (authors.Any(a => a.FirstName == firstName && a.LastName == lastName && a.DateOfBirth == dateOfBirth))
            {
                Console.WriteLine("Author already exists..!");
                return;
            }
            Author author = new Author { FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth };
            authors.Add(author);
            Console.WriteLine("author added succesfuly..!");
            Console.WriteLine();
        }
        //Update author
        static void UpdateAuthor() {

            Console.WriteLine("Write a first name of author that you want to update: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Write a last name of author that you want to udpate: ");
            string lName = Console.ReadLine();

            var author = authors.Find(a => a.FirstName == fName && a.LastName == lName);
            if(author != null)
            {
                Console.WriteLine("Enter the updated author's first name (or press enter to keep the existing first name):");
                string updatedFirstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedFirstName))
                {
                    author.FirstName = updatedFirstName;
                }

                Console.WriteLine("Enter the updated author's last name (or press enter to keep the existing last name):");
                string updatedLastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedLastName))
                {
                    author.LastName = updatedLastName;
                }


                Console.WriteLine("Author updated successfully!");

            }
            else
            {
                Console.WriteLine("Author doesn't exists..!");
            }

            Console.WriteLine();
        }
        //Remove author
        static void DeleteAuthor()
        {
            Console.WriteLine("Write first name of author that you want to delete: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Write last name of author that you want to delete: ");
            string lName = Console.ReadLine();
            

            var author = authors.Find(a => a.FirstName==fName && a.LastName ==lName);

            if (author != null)
            {
                authors.Remove(author);
                Console.WriteLine($"{fName} {lName} remove from authors list..!");
            }
            else
            {
                Console.WriteLine("author with this name doesn't exists..!");
            }
            Console.WriteLine();
        }
        //List author
        static void ListAllAuthor() {
            if (authors.Count() == 0)
            {
                Console.WriteLine("No authors available in library..!");
            }
            foreach (var author in authors)
            {
                Console.WriteLine(author.ToString());
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        //add borrower
        static void AddBorrower() {
            Console.WriteLine("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            Borrower borrower = new Borrower { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNumber };
            borrowers.Add(borrower);
            Console.WriteLine("borrower added succesfuly..!");
            Console.WriteLine();
        }
        //update borrower
        static void UpdateBorrower() {
            Console.WriteLine("Write a first name of borrower that you want to update: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Write a last name of borrower that you want to udpate: ");
            string lName = Console.ReadLine();

            var borrower = borrowers.Find(b => b.FirstName == fName && b.LastName == lName);

            if (borrower != null)
            {
                Console.WriteLine("Enter the updated borrower's first name (or press enter to keep the existing first name):");
                string updatedFirstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedFirstName))
                {
                    borrower.FirstName = updatedFirstName;
                }

                Console.WriteLine("Enter the updated borrower's last name (or press enter to keep the existing last name):");
                string updatedLastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedLastName))
                {
                    borrower.LastName = updatedLastName;
                }
                Console.WriteLine("Enter the updated borrower's email (or press enter to keep the existing email):");
                string updatedEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedEmail))
                {
                    borrower.Email = updatedEmail;
                }
                Console.WriteLine("Enter the updated borrower's phone number (or press enter to keep the existing phone number):");
                string updatedPhoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(updatedPhoneNumber))
                {
                    borrower.PhoneNumber = updatedEmail;
                }
                Console.WriteLine("Borrower updated successfully!");
            }
            else {
                Console.WriteLine("Borrower doesn't exists..");
            }

            Console.WriteLine();
        }
        //delete borrower
        static void DeleteBorrower() {

            Console.WriteLine("Write first name of borrower that you want to delete: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Write last name of borrower that you want to delete: ");
            string lName = Console.ReadLine();


            var borrower = borrowers.Find(b => b.FirstName == fName && b.LastName == lName);

            if (borrower != null)
            {
                borrowers.Remove(borrower);
                Console.WriteLine($"{fName} {lName} remove from borrowers list..!");
            }
            else
            {
                Console.WriteLine("borrower with this name doesn't exists..!");
            }
            Console.WriteLine();
        }
        //list borrower
        static void ListAllBorrower() {
            if(borrowers.Count==0) {
                Console.WriteLine("No borrowers available in library..!");
            }
            foreach (var borrower in borrowers)
            {
                Console.WriteLine(borrower.ToString());
            }
            Console.WriteLine();
        }

        static void SearchBooks()
        {
            Console.WriteLine("Write a search title ");
            string title = Console.ReadLine();

            var results = books.Where(b => b.Title.Contains(title));
            if (results.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (Book book in results)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}, Status: {(book.IsAvailable ? "Available" : "Borrowed")}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No results found!");
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
            return $"Title: {Title}\nAuthor {Author.FirstName} {Author.LastName}\nDate of Birth: {Author.DateOfBirth}\nPublication Year: {PublicationYear}\nIsAvailable: {IsAvailable}";
        }
    }

   
    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\nDate of Birth: {DateOfBirth}";
        }

    }

    class Borrower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\nEmail: {Email}\nPhone number: {PhoneNumber}";
        }
    }
}