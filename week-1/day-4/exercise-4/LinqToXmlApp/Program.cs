using System.Xml.Linq;

namespace LinqToXmlApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Assume there is an XML document with the following structure:
            // <Books>
            //     <Book>
            //         <Title>Book Title 1</Title>
            //         <Author>Author 1</Author>
            //         <Genre>Genre 1</Genre>
            //     </Book>
            //     ...
            // </Books>
            // Write above book structure as a c# string
            string xmlString = @"<Books>
                                    <Book>
                                        <Title>Book Title 1</Title>
                                        <Author>Author 1</Author>
                                        <Genre>Genre 1</Genre>
                                    </Book>
                                    <Book>
                                        <Title>Book Title 2</Title>
                                        <Author>Author 2</Author>
                                        <Genre>Genre 2</Genre>
                                    </Book>
                                    <Book>
                                        <Title>Book Title 3</Title>
                                        <Author>Author 3</Author>
                                        <Genre>Genre 3</Genre>
                                    </Book>
                                </Books>";

            // Create an XDocument object from the XML string

            XDocument xDocument = XDocument.Parse(xmlString);
            //var books = xDocument.Elements();
            var books = xDocument.Descendants("Book");

            foreach ( var book in books )
            {
                string title = book.Element("Title").Value;
                Console.WriteLine("Title: "+title);
            }

            // Write the title of all books to the console

            // Write the title of all books with genre "Genre 1" to the console
            Console.WriteLine("title of all books with genre \"Genre 1\"");
            var genre1BookTitles = books.Where(book => book.Element("Genre").Value == "Genre 1");
            foreach( var book in genre1BookTitles)
            {
                string title = book.Element("Title").Value;
                Console.WriteLine("Title: " + title);


            }

            Console.ReadLine();
        }
    }
}